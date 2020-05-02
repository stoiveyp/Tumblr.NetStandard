using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
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

        public Task<ApiResponse<BlogPostResult>> Posts()
        {
            var uri = ClientDetail.CreateUri(BlogApiPart.Posts.ApiPath(FullBlogName), ClientDetail.StandardPostDictionary.AddNpf(ClientDetail));
            return ClientDetail.MakeGetRequest<BlogPostResult>(uri);
        }

        public Task<ApiResponse<BlogPostResult>> Posts(int offset, int pageSize)
        {
            var posts = ClientDetail.StandardPostDictionary.AddNpf(ClientDetail);

            posts.Add(nameof(offset), offset.ToString());
            posts.Add("limit", pageSize.ToString());

            var uri = ClientDetail.CreateUri(BlogApiPart.Posts.ApiPath(FullBlogName), posts);
            return ClientDetail.MakeGetRequest<BlogPostResult>(uri);
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
    }
}
