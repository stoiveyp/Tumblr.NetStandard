using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard
{
    internal class TumblrUserMethods : ITumblrUserMethods
    {
        private TumblrClientDetail ClientDetail { get; }

        public TumblrUserMethods(TumblrClientDetail detail)
        {
            ClientDetail = detail;
        }

        public Task<ApiResponse<DashboardResult>> Dashboard()
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<DashboardResult>());
            }

            var uri = ClientDetail.CreateUri(UserApiPart.Dashboard.ApiPath(), ClientDetail.StandardPostDictionary.AddNpf(ClientDetail));
            return ClientDetail.MakeGetRequest<DashboardResult>(uri);
        }

        public Task<ApiResponse<DashboardResult>> Dashboard(int offset, int limit)
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<DashboardResult>());
            }

            var posts = ClientDetail.StandardPostDictionary.AddNpf(ClientDetail);
            posts.Add("offset", offset.ToString());
            posts.Add("limit", limit.ToString());

            var uri = ClientDetail.CreateUri(UserApiPart.Dashboard.ApiPath(), posts);
            return ClientDetail.MakeGetRequest<DashboardResult>(uri);
        }

        public Task<ApiResponse<UserLikeResult>> Likes()
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<UserLikeResult>());
            }

            var uri = ClientDetail.CreateUri(UserApiPart.Likes.ApiPath(), ClientDetail.StandardPostDictionary.AddNpf(ClientDetail));
            return ClientDetail.MakeGetRequest<UserLikeResult>(uri);
        }

        public Task<ApiResponse<FollowingResult>> Following(int offset = 0)
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<FollowingResult>());
            }

            var uri = ClientDetail.CreateUri(UserApiPart.Following.ApiPath(), new Dictionary<string, string> { { "offset", offset.ToString() } }.AddNpf(ClientDetail));
            return ClientDetail.MakeGetRequest<FollowingResult>(uri);
        }

        public Task<ApiResponse<UserInfoResult>> Info()
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<UserInfoResult>());
            }

            var uri = ClientDetail.CreateUri(UserApiPart.Info.ApiPath());
            return ClientDetail.MakeGetRequest<UserInfoResult>(uri);
        }
    }
}
