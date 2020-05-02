using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard
{
    public interface ITumblrUserMethods
    {
        Task<ApiResponse<DashboardResult>> Dashboard();
        Task<ApiResponse<DashboardResult>> Dashboard(int offset, int limit);


        Task<ApiResponse<UserLikeResult>> Likes();
        Task<ApiResponse<FollowingResult>> Following(int offset = 0);
        Task<ApiResponse<UserInfoResult>> Info();
    }
}
