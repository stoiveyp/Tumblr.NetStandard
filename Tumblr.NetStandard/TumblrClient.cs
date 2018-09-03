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
using Tumblr.NetStandard.Models.CallResult;
using Tumblr.NetStandard.OAuth;

namespace Tumblr.NetStandard
{
    public class TumblrClient : ITumblrClient
    {
        private readonly HttpClient Client;
        private readonly bool UseApiKey;
        private readonly string ConsumerKey;
        private readonly Dictionary<string, string> StandardPostDictionary = new Dictionary<string, string> { { "notes_info", "true" }, { "reblog_info", "true" } };
        private readonly JsonSerializer Serializer = JsonSerializer.Create(new JsonSerializerSettings
        {
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            Converters = { new EpochDateTimeHandler(), new PostConverter(), new NoteConverter() }
        });

        public Action<string> OnError { get; set; }

        public TumblrClient(TumblrClientCredentials consumer) : this(null, consumer)
        {

        }

        public TumblrClient(HttpMessageHandler handler, TumblrClientCredentials consumer) : this(handler, consumer, null)
        {

        }

        public TumblrClient(TumblrClientCredentials consumer, TumblrCredentials token) : this(null, consumer, token)
        {

        }

        public TumblrClient(HttpMessageHandler handler, TumblrClientCredentials consumer, TumblrCredentials token)
        {
            AccessToken accessToken = null;
            ConsumerKey = consumer.Id;

            if (string.IsNullOrWhiteSpace(token.Key) || string.IsNullOrWhiteSpace(token.Secret))
            {
                UseApiKey = true;
            }
            else
            {
                accessToken = new AccessToken(token.Key, token.Secret);
            }
            var oAuthMessageHandler = handler == null ? new OAuthMessageHandler(consumer.Id, consumer.Secret, accessToken) : new OAuthMessageHandler(handler, consumer.Id, consumer.Secret, accessToken);
            Client = new HttpClient(oAuthMessageHandler);
        }

        public Task<ApiResponse<BlogPostResult>> BlogPosts(string name)
        {
            var uri = CreateUri(ApiPath(name, BlogApiPart.Posts), StandardPostDictionary);
            return MakeGetRequest<BlogPostResult>(uri);
        }

        public Task<ApiResponse<DashboardResult>> Dashboard()
        {
            if (UseApiKey)
            {
                return Task.FromResult(HandleNotLoggedIn<DashboardResult>());
            }

            var uri = CreateUri(ApiPath(UserApiPart.Dashboard), StandardPostDictionary);
            return MakeGetRequest<DashboardResult>(uri);
        }

        private ApiResponse<T> HandleNotLoggedIn<T>()
        {
            var notLoggedIn = ErrorCall.NotLoggedIn<T>();
            OnError?.Invoke(notLoggedIn.Meta.Message);
            return notLoggedIn;
        }

        public Task<ApiResponse<UserLikeResult>> Likes()
        {
            if (UseApiKey)
            {
                return Task.FromResult(HandleNotLoggedIn<UserLikeResult>());
            }

            var uri = CreateUri(ApiPath(UserApiPart.Likes), StandardPostDictionary);
            return MakeGetRequest<UserLikeResult>(uri);
        }

        public Task<ApiResponse<FollowingResult>> Following(int offset = 0)
        {
            if (UseApiKey)
            {
                return Task.FromResult(HandleNotLoggedIn<FollowingResult>());
            }

            var uri = CreateUri(ApiPath(UserApiPart.Following),new Dictionary<string, string>{{"offset",offset.ToString()}});
            return MakeGetRequest<FollowingResult>(uri);
        }

        public Task<ApiResponse<UserInfoResult>> UserInfo()
        {
            if (UseApiKey)
            {
                return Task.FromResult(HandleNotLoggedIn<UserInfoResult>());
            }

            var uri = CreateUri(ApiPath(UserApiPart.Info));
            return MakeGetRequest<UserInfoResult>(uri);
        }

        public Task<ApiResponse<Post[]>> Tagged(string tag)
        {
            var uri = CreateUri(TaggedPath(),new Dictionary<string, string>{{"tag",tag}});
            return MakeGetRequest<Post[]>(uri);
        }

        public Task<ApiResponse<bool>> Like(long postId, string reblogKey)
        {
            if (UseApiKey)
            {
                return Task.FromResult(HandleNotLoggedIn<bool>());
            }

            var dictionary = new Dictionary<string, string> { { "id", postId.ToString() }, { "reblog_key", reblogKey } };

            var uri = CreateUri(ApiPath(UserApiPart.Like));
            return MakeStatusPost(uri, dictionary, HttpStatusCode.OK);
        }

        public Task<ApiResponse<bool>> Unlike(long postId, string reblogKey)
        {
            if (UseApiKey)
            {
                return Task.FromResult(HandleNotLoggedIn<bool>());
            }

            var dictionary = new Dictionary<string, string> { { "id", postId.ToString() }, { "reblog_key", reblogKey } };

            var uri = CreateUri(ApiPath(UserApiPart.Unlike));
            return MakeStatusPost(uri, dictionary, HttpStatusCode.OK);
        }

        private async Task<ApiResponse<bool>> MakeStatusPost(Uri uri, Dictionary<string, string> dictionary, HttpStatusCode acceptableCode = HttpStatusCode.Created)
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

        private Task<ApiResponse<T>> MakeStandardPost<T>(Uri uri, Dictionary<string, string> dictionary, HttpStatusCode acceptableCode = HttpStatusCode.Created)
        {
            return MakeStandardCall<T>(uri, async (c, u) =>
            {
                var content = new FormUrlEncodedContent(dictionary);
                var response = await Client.PostAsync(uri, content);
                return await response.Content.ReadAsStreamAsync();
            }, acceptableCode);
        }

        private Task<ApiResponse<T>> MakeGetRequest<T>(Uri uri, HttpStatusCode acceptableCode = HttpStatusCode.OK)
        {
            return MakeStandardCall<T>(uri, (c, u) => c.GetStreamAsync(u), acceptableCode);
        }

        private async Task<ApiResponse<T>> MakeStandardCall<T>(Uri uri, Func<HttpClient,Uri,Task<Stream>> getStream,HttpStatusCode acceptableCode = HttpStatusCode.OK)
        {
            try
            {
                var stream = await getStream(Client,uri).ConfigureAwait(false);
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

        private string TaggedPath()
        {
            return "tagged";
        }

        private string ApiPath(UserApiPart blogPart)
        {
            return $"user/{TranslatePart(blogPart)}";
        }

        private string ApiPath(string candidate, BlogApiPart blogPart)
        {
            return $"blog/{candidate}{(!candidate.Contains(".") ? ".tumblr.com" : string.Empty)}/{TranslatePart(blogPart)}";
        }

        private string TranslatePart(UserApiPart part)
        {
            switch (part)
            {
                case UserApiPart.Dashboard:
                    return "dashboard";
                case UserApiPart.Likes:
                    return "likes";
                case UserApiPart.Following:
                    return "following";
                case UserApiPart.Like:
                    return "like";
                case UserApiPart.Unlike:
                    return "unlike";
                default:
                    return "info";
            }
        }

        private string TranslatePart(BlogApiPart part)
        {
            switch (part)
            {
                case BlogApiPart.Posts:
                    return "posts";
                default:
                    return "info";
            }
        }

        private Uri CreateUri(string path, Dictionary<string, string> query = null)
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
                queryValues.Add("api_key", ConsumerKey);
            }

            var iterate = queryValues.Select(kvp => $"{System.Net.WebUtility.UrlEncode(kvp.Key)}={System.Net.WebUtility.UrlEncode(kvp.Value)}");
            return string.Join("&", iterate.ToArray());
        }
    }
}
