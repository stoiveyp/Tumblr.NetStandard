using System;
using System.Threading.Tasks;
using Tumblr.NetStandard.Models;
using Tumblr.NetStandard.Models.CallResult;

namespace Tumblr.NetStandard
{
    public interface ITumblrClient
    {
        Action<string> OnError { get; set; }

        Task<ApiResponse<BlogPostResult>> BlogPosts(string name);
        Task<ApiResponse<DashboardResult>> Dashboard();
        Task<ApiResponse<UserLikeResult>> Likes();
        Task<ApiResponse<FollowingResult>> Following(int offset = 0);
        Task<ApiResponse<UserInfoResult>> UserInfo();
        Task<ApiResponse<bool>> Like(long postId, string reblogKey);
        Task<ApiResponse<bool>> Unlike(long postId, string reblogKey);
        Task<ApiResponse<Post[]>> Tagged(string searchTerm);
    }
}