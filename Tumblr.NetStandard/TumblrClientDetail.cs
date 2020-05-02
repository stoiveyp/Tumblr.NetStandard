using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tumblr.NetStandard.Api;
using Tumblr.NetStandard.OAuth;

namespace Tumblr.NetStandard
{
    public class TumblrClientDetail
    {
        public HttpClient Client { get; set; }
        public AccessToken AccessToken { get; set; }
        public bool UseApiKey { get; set; }

        public bool UseNpf { get; set; } = true;
        public TumblrClientCredentials ClientCreds { get; set; }
        public Action<string> OnError { get; set; }
        public Dictionary<string, string> StandardPostDictionary => new Dictionary<string, string>
            {{"notes_info", "true"}, {"reblog_info", "true"}};

        public readonly JsonSerializer Serializer = JsonSerializer.Create(new JsonSerializerSettings
        {
            DateTimeZoneHandling = DateTimeZoneHandling.Utc
        });

        public ApiResponse<T> HandleNotLoggedIn<T>()
        {
            var notLoggedIn = ErrorCall.NotLoggedIn<T>();
            OnError?.Invoke(notLoggedIn.Meta.Message);
            return notLoggedIn;
        }

        public Uri CreateUri(string path, Dictionary<string, string> query = null)
        {
            var builder = new UriBuilder("https", "api.tumblr.com")
            {
                Path = $"/v2/{path}", 
                Query = CreateQueryString(query)
            };
            return builder.Uri;
        }

        private string CreateQueryString(Dictionary<string, string> queryValues, bool npfAware = false)
        {
            queryValues ??= new Dictionary<string, string>();
            if (UseApiKey)
            {
                queryValues.Add("api_key", ClientCreds.Id);
            }

            if (UseNpf && npfAware)
            {
                queryValues.Add("npf",true.ToString().ToLower());
            }

            var iterate = queryValues.Select(kvp => $"{System.Net.WebUtility.UrlEncode(kvp.Key)}={System.Net.WebUtility.UrlEncode(kvp.Value)}");
            return string.Join("&", iterate.ToArray());
        }

        public async Task<ApiResponse<T>> MultipartFormRequest<T>(Uri uri, object content, Dictionary<string,Stream> streams = null, HttpStatusCode acceptableCode = HttpStatusCode.Created)
        {
            var requestContent = new MultipartFormDataContent
            {
                new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8)
            };

            if (streams != null)
            {
                foreach (var stream in streams)
                {
                    requestContent.Add(new StreamContent(stream.Value), stream.Key);
                }
            }

            return await MakeStandardCall<T>(uri, async (c, u) =>
            {
                var response = await Client.PostAsync(uri, requestContent).ConfigureAwait(false);
                return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            }, acceptableCode);
        }

        public async Task<ApiResponse<bool>> FormEncodedPostRequest(Uri uri, Dictionary<string, string> dictionary, HttpStatusCode acceptableCode = HttpStatusCode.Created)
        {
            var result = await MakeStandardCall<object[]>(uri, async (c, u) =>
            {
                var content = new FormUrlEncodedContent(dictionary);
                var response = await Client.PostAsync(uri, content).ConfigureAwait(false);
                return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            }, acceptableCode);
            var newResponse = new ApiResponse<bool>
            {
                Meta = result.Meta,
                Response = result.Success
            };
            return newResponse;
        }

        public Task<ApiResponse<T>> MakeGetRequest<T>(Uri uri, HttpStatusCode acceptableCode = HttpStatusCode.OK)
        {
            return MakeStandardCall<T>(uri, (c, u) => c.GetStreamAsync(u), acceptableCode);
        }

        public async Task<ApiResponse<T>> MakeStandardCall<T>(Uri uri, Func<HttpClient, Uri, Task<Stream>> getStream, HttpStatusCode acceptableCode = HttpStatusCode.OK)
        {
            try
            {
                var stream = await getStream(Client, uri).ConfigureAwait(false);

                using var reader = new JsonTextReader(new StreamReader(stream, Encoding.UTF8));
                var result = Serializer.Deserialize<ApiResponse<T>>(reader);

                if (result.Meta.Code != acceptableCode)
                {
                    result.Success = false;
                    OnError?.Invoke(result.Meta.Message);
                }
                return result;
            }
            catch (HttpRequestException)
            {
                var networkError = ErrorCall.NetworkError<T>();
                OnError?.Invoke(networkError.Meta.Message);
                return networkError;
            }
            catch (Exception)
            {
                //TECHDEBT: Add Error Logs
                var unknown = ErrorCall.Unknown<T>();
                OnError?.Invoke(unknown.Meta.Message);
                return unknown;
            }
        }
    }
}
