using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tumblr.NetStandard.Api;
using Tumblr.NetStandard.Conversion;

namespace Tumblr.NetStandard
{
    internal class TumblrUserMethods : ITumblrUserMethods
    {
        private TumblrClientDetail ClientDetail { get; }

        public TumblrUserMethods(TumblrClientDetail detail)
        {
            ClientDetail = detail;
        }

        public Task<ApiResponse<PostsResult>> Dashboard()
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<PostsResult>());
            }

            var uri = ClientDetail.CreateUri(UserApiPart.Dashboard.ApiPath(), ClientDetail.StandardPostDictionary.AddNpf(ClientDetail));
            return ClientDetail.MakeGetRequest<PostsResult>(uri);
        }

        public Task<ApiResponse<PostsResult>> Dashboard(int offset, int? limit = null)
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<PostsResult>());
            }

            var posts = ClientDetail.StandardPostDictionary.AddNpf(ClientDetail);
            posts.Add("offset", offset.ToString());
            if (limit.HasValue)
            {
                posts.Add("limit", limit.ToString());
            }

            var uri = ClientDetail.CreateUri(UserApiPart.Dashboard.ApiPath(), posts);
            return ClientDetail.MakeGetRequest<PostsResult>(uri);
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

        public Task<ApiResponse<UserLikeResult>> Likes(int offset, int? limit = null)
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<UserLikeResult>());
            }

            var posts = ClientDetail.StandardPostDictionary.AddNpf(ClientDetail);
            posts.Add("offset", offset.ToString());
            if (limit.HasValue)
            {
                posts.Add("limit", limit.ToString());
            }

            var uri = ClientDetail.CreateUri(UserApiPart.Likes.ApiPath(), posts);
            return ClientDetail.MakeGetRequest<UserLikeResult>(uri);
        }

        public Task<ApiResponse<UserLikeResult>> Likes(DateTime timestamp, LikeTimestampKind kind)
        {
            return Likes(timestamp.UtcToEpoch(), kind);
        }

        public Task<ApiResponse<UserLikeResult>> Likes(long timestamp, LikeTimestampKind kind)
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<UserLikeResult>());
            }

            var posts = ClientDetail.StandardPostDictionary.AddNpf(ClientDetail);
            posts.Add(kind == LikeTimestampKind.After ? "after" : "before", timestamp.ToString());

            var uri = ClientDetail.CreateUri(UserApiPart.Likes.ApiPath(), ClientDetail.StandardPostDictionary.AddNpf(ClientDetail));
            return ClientDetail.MakeGetRequest<UserLikeResult>(uri);
        }

        public Task<ApiResponse<FollowingResult>> Following(int offset = 0, int? limit = null)
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<FollowingResult>());
            }

            var prms = new Dictionary<string, string> {{"offset", offset.ToString()}};
            if (limit.HasValue)
            {
                prms.Add("limit",limit.Value.ToString());
            }

            var uri = ClientDetail.CreateUri(UserApiPart.Following.ApiPath(), prms);
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
