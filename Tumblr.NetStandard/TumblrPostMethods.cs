using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard
{
    public class TumblrPostMethods:ITumblrPostMethods
    {
        private Post Post { get; }
        private TumblrClientDetail ClientDetail { get; }

        public TumblrPostMethods(Post post, TumblrClientDetail clientDetail)
        {
            ClientDetail = clientDetail;
        }

        public Task<ApiResponse<bool>> Like()
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<bool>());
            }

            var dictionary = new Dictionary<string, string> { { "id", Post.Id.ToString() }, { "reblog_key", Post.ReblogKey } };

            var uri = ClientDetail.CreateUri(UserApiPart.Like.ApiPath());
            return ClientDetail.FormEncodedPostRequest(uri, dictionary, HttpStatusCode.OK);
        }

        public Task<ApiResponse<bool>> Unlike()
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<bool>());
            }

            var dictionary = new Dictionary<string, string> { { "id", Post.Id.ToString() }, { "reblog_key", Post.ReblogKey } };

            var uri = ClientDetail.CreateUri(UserApiPart.Unlike.ApiPath());
            return ClientDetail.FormEncodedPostRequest(uri, dictionary, HttpStatusCode.OK);
        }

        public Task<ApiResponse<bool>> Delete()
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<bool>());
            }

            var dictionary = new Dictionary<string, string> { { "id", Post.Id.ToString() } };

            var uri = ClientDetail.CreateUri(BlogApiPart.Delete.ApiPath(Post.BlogName));
            return ClientDetail.FormEncodedPostRequest(uri, dictionary, HttpStatusCode.OK);
        }
    }
}
