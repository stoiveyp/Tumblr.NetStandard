using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tumblr.NetStandard.Conversion;
using Tumblr.NetStandard.Models;
using Tumblr.NetStandard.OAuth;

namespace Tumblr.NetStandard
{
    public class TumblrClientDetail
    {
        public HttpClient Client { get; set; }
        public AccessToken AccessToken { get; set; }
        public bool UseApiKey { get; set; }
        public TumblrClientCredentials ClientCreds { get; set; }
        public Action<string> OnError { get; set; }

        public readonly Dictionary<string, string> StandardPostDictionary = new Dictionary<string, string>
            {{"notes_info", "true"}, {"reblog_info", "true"}};

        public readonly JsonSerializer Serializer = JsonSerializer.Create(new JsonSerializerSettings
        {
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            Converters = { new EpochDateTimeHandler(), new PostConverter(), new NoteConverter() }
        });

        public ApiResponse<T> HandleNotLoggedIn<T>()
        {
            var notLoggedIn = ErrorCall.NotLoggedIn<T>();
            OnError?.Invoke(notLoggedIn.Meta.Message);
            return notLoggedIn;
        }

        public Uri CreateUri(string path, Dictionary<string, string> query = null)
        {
            var builder = new UriBuilder("https", "api.tumblr.com");
            builder.Path = $"/v2/{path}";
            builder.Query = CreateQueryString(query);
            return builder.Uri;
        }

        private string CreateQueryString(Dictionary<string, string> queryValues)
        {
            queryValues = queryValues ?? new Dictionary<string, string>();
            if (UseApiKey)
            {
                queryValues.Add("api_key", ClientCreds.Id);
            }

            var iterate = queryValues.Select(kvp => $"{System.Net.WebUtility.UrlEncode(kvp.Key)}={System.Net.WebUtility.UrlEncode(kvp.Value)}");
            return string.Join("&", iterate.ToArray());
        }

        public async Task<ApiResponse<bool>> MakeStatusPost(Uri uri, Dictionary<string, string> dictionary, HttpStatusCode acceptableCode = HttpStatusCode.Created)
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

        public Task<ApiResponse<T>> MakeStandardPost<T>(Uri uri, Dictionary<string, string> dictionary, HttpStatusCode acceptableCode = HttpStatusCode.Created)
        {
            return MakeStandardCall<T>(uri, async (c, u) =>
            {
                var content = new FormUrlEncodedContent(dictionary);
                var response = await Client.PostAsync(uri, content);
                return await response.Content.ReadAsStreamAsync();
            }, acceptableCode);
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
                using (var reader = new JsonTextReader(new StreamReader(stream, Encoding.UTF8)))
                {
                    var result = Serializer.Deserialize<ApiResponse<T>>(reader);
                    if (result.Meta.Code != acceptableCode)
                    {
                        result.Success = false;
                        OnError?.Invoke(result.Meta.Message);
                    }
                    return result;
                }
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
