using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard
{
    public interface ITumblrUserMethods
    {
        Task<ApiResponse<PostsResult>> Dashboard();
        Task<ApiResponse<PostsResult>> Dashboard(int offset, int? limit = 0);

        Task<ApiResponse<UserLikeResult>> Likes();
        Task<ApiResponse<UserLikeResult>> Likes(int offset, int? limit = 0);
        Task<ApiResponse<UserLikeResult>> Likes(DateTime timestamp, LikeTimestampKind kind);
        Task<ApiResponse<UserLikeResult>> Likes(long timestamp, LikeTimestampKind kind);

        Task<ApiResponse<FollowingResult>> Following(int offset = 0, int? limit = 0);
        Task<ApiResponse<UserInfoResult>> Info();
    }
}
