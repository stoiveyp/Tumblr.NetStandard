using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard
{
    internal class TumblrBlogMethods : ITumblrBlogMethods
    {
        private string BlogName { get; }
        private string FullBlogName { get; }
        private TumblrClientDetail ClientDetail { get; }

        public TumblrBlogMethods(string blogName, TumblrClientDetail clientDetail)
        {
            BlogName = blogName;
            FullBlogName = $"{blogName}{(!blogName.Contains(".") ? ".tumblr.com" : string.Empty)}";
            ClientDetail = clientDetail;
        }

        public Task<ApiResponse<BlogPostResult>> Posts(BlogPostRequest request = null)
        {
            var dictionary = ToDictionary(ClientDetail.StandardPostDictionary.AddNpf(ClientDetail),request);
            if (dictionary.ContainsKey("type"))
            {
                dictionary.Remove("type");
            }
            var uri = ClientDetail.CreateUri(BlogApiPart.Posts.ApiPath(FullBlogName,request?.Type), dictionary);
            return ClientDetail.MakeGetRequest<BlogPostResult>(uri);
        }

        private Dictionary<string, string> ToDictionary(Dictionary<string, string> original, object request)
        {
            if (request == null)
            {
                return original;
            }

            var props = JObject.FromObject(request);
            foreach (var prop in props.Properties())
            {
                if (!original.ContainsKey(prop.Name))
                {
                    original.Add(prop.Name,prop.Value<string>());
                }
            }

            return original;
        }

        public Task<ApiResponse<BlogPostResult>> Posts(int offset, int pageSize)
        {
            var posts = ClientDetail.StandardPostDictionary.AddNpf(ClientDetail);

            posts.Add(nameof(offset), offset.ToString());
            posts.Add("limit", pageSize.ToString());

            var uri = ClientDetail.CreateUri(BlogApiPart.Posts.ApiPath(FullBlogName), posts);
            return ClientDetail.MakeGetRequest<BlogPostResult>(uri);
        }

        public Task<ApiResponse<BlogFollowingResult>> Following()
        {
            var uri = ClientDetail.CreateUri(BlogApiPart.Following.ApiPath(FullBlogName));
            return ClientDetail.MakeGetRequest<BlogFollowingResult>(uri);
        }

        public Task<ApiResponse<BlogFollowingResult>> Following(int offset, int pageSize)
        {
            var posts = new Dictionary<string, string>
            {
                {nameof(offset), offset.ToString()}, 
                {"limit", pageSize.ToString()}
            };


            var uri = ClientDetail.CreateUri(BlogApiPart.Following.ApiPath(FullBlogName), posts);
            return ClientDetail.MakeGetRequest<BlogFollowingResult>(uri);
        }


        public Task<ApiResponse<BlogFollowersResult>> Followers()
        {
            var uri = ClientDetail.CreateUri(BlogApiPart.Followers.ApiPath(FullBlogName));
            return ClientDetail.MakeGetRequest<BlogFollowersResult>(uri);
        }

        public Task<ApiResponse<BlogFollowersResult>> Followers(int offset, int pageSize)
        {
            var posts = new Dictionary<string, string>
            {
                {nameof(offset), offset.ToString()},
                {"limit", pageSize.ToString()}
            };


            var uri = ClientDetail.CreateUri(BlogApiPart.Followers.ApiPath(FullBlogName), posts);
            return ClientDetail.MakeGetRequest<BlogFollowersResult>(uri);
        }

        public Task<ApiResponse<bool>> Follow()
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<bool>());
            }

            var dictionary = new Dictionary<string, string> { { "url",FullBlogName } };

            var uri = ClientDetail.CreateUri(UserApiPart.Follow.ApiPath());
            return ClientDetail.FormEncodedPostRequest(uri, dictionary, HttpStatusCode.OK);
        }

        public Task<ApiResponse<bool>> Unfollow()
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<bool>());
            }

            var dictionary = new Dictionary<string, string> { { "url", FullBlogName } };

            var uri = ClientDetail.CreateUri(UserApiPart.Unfollow.ApiPath());
            return ClientDetail.FormEncodedPostRequest(uri, dictionary, HttpStatusCode.OK);
        }

        public Task<ApiResponse<BlogInfoResult>> Info()
        {
            var uri = ClientDetail.CreateUri(BlogApiPart.Info.ApiPath(FullBlogName));
            return ClientDetail.MakeGetRequest<BlogInfoResult>(uri);
        }

        public Task<ApiResponse<PostsResult>> Submission()
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<PostsResult>());
            }

            var uri = ClientDetail.CreateUri(BlogApiPart.Submission.ApiPath(FullBlogName), new Dictionary<string, string>().AddNpf(ClientDetail));
            return ClientDetail.MakeGetRequest<PostsResult>(uri);
        }

        public Task<ApiResponse<PostsResult>> Submission(int offset, int pageSize)
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<PostsResult>());
            }

            var posts = new Dictionary<string, string>
            {
                {nameof(offset), offset.ToString()},
                {"limit", pageSize.ToString()}
            };

            var uri = ClientDetail.CreateUri(BlogApiPart.Submission.ApiPath(FullBlogName), posts.AddNpf(ClientDetail));
            return ClientDetail.MakeGetRequest<PostsResult>(uri);
        }

        public Task<ApiResponse<PostsResult>> Queue()
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<PostsResult>());
            }

            var uri = ClientDetail.CreateUri(BlogApiPart.Queue.ApiPath(FullBlogName), new Dictionary<string, string>().AddNpf(ClientDetail));
            return ClientDetail.MakeGetRequest<PostsResult>(uri);
        }

        public Task<ApiResponse<PostsResult>> Queue(int offset, int pageSize)
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<PostsResult>());
            }

            var posts = new Dictionary<string, string>
            {
                {nameof(offset), offset.ToString()},
                {"limit", pageSize.ToString()}
            };

            var uri = ClientDetail.CreateUri(BlogApiPart.Queue.ApiPath(FullBlogName), posts.AddNpf(ClientDetail));
            return ClientDetail.MakeGetRequest<PostsResult>(uri);
        }

        public Task<ApiResponse<PostsResult>> Drafts()
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<PostsResult>());
            }

            var uri = ClientDetail.CreateUri(BlogApiPart.Draft.ApiPath(FullBlogName), new Dictionary<string, string>().AddNpf(ClientDetail));
            return ClientDetail.MakeGetRequest<PostsResult>(uri);
        }

        public Task<ApiResponse<PostsResult>> Drafts(ulong beforeId)
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<PostsResult>());
            }

            var posts = new Dictionary<string, string>
            {
                {"before_id", beforeId.ToString()}
            };

            var uri = ClientDetail.CreateUri(BlogApiPart.Draft.ApiPath(FullBlogName), new Dictionary<string, string>().AddNpf(ClientDetail));
            return ClientDetail.MakeGetRequest<PostsResult>(uri);
        }

        public Uri AvatarUri(int size)
        {
            return new Uri($"https://api.tumblr.com/v2/blog/{FullBlogName}/avatar/{size}",UriKind.Absolute);
        }
    }
}
