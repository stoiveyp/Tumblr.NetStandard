using System;
using System.Threading.Tasks;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard
{
    public interface ITumblrBlogMethods
    {
        Task<ApiResponse<BlogPostResult>> Posts(BlogPostRequest request = null);

        Task<ApiResponse<bool>> Follow();
        Task<ApiResponse<bool>> Unfollow();

        Task<ApiResponse<BlogFollowingResult>> Following();
        Task<ApiResponse<BlogFollowingResult>> Following(int offset, int limit);
        Task<ApiResponse<BlogFollowersResult>> Followers();
        Task<ApiResponse<BlogFollowersResult>> Followers(int offset, int limit);

        Task<ApiResponse<BlogInfoResult>> Info();

        Task<ApiResponse<PostsResult>> Submission();
        Task<ApiResponse<PostsResult>> Submission(int offset, int limit);
        Task<ApiResponse<PostsResult>> Queue();
        Task<ApiResponse<PostsResult>> Queue(int offset, int limit);
        Task<ApiResponse<PostsResult>> Drafts();
        Task<ApiResponse<PostsResult>> Drafts(ulong beforeId);

        Uri AvatarUri(int size);
    }
}
