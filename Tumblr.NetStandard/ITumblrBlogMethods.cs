using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Tumblr.NetStandard.Api;
using Tumblr.NetStandard.NPF;

namespace Tumblr.NetStandard
{
    public interface ITumblrBlogMethods
    {
        Task<ApiResponse<BlogPostResult>> Posts(BlogPostRequest request = null);
        Task<ApiResponse<BlogPostResult>> Posts(int offset, int? limit = null);

        Task<ApiResponse<bool>> Follow();
        Task<ApiResponse<bool>> Unfollow();

        Task<ApiResponse<BlogFollowingResult>> Following();
        Task<ApiResponse<BlogFollowingResult>> Following(int offset, int? limit = null);
        Task<ApiResponse<BlogFollowersResult>> Followers();
        Task<ApiResponse<BlogFollowersResult>> Followers(int offset, int? limit = null);

        Task<ApiResponse<BlogInfoResult>> Info();

        Task<ApiResponse<PostsResult>> Submission();
        Task<ApiResponse<PostsResult>> Submission(int offset, int? limit = null);
        Task<ApiResponse<PostsResult>> Queue();
        Task<ApiResponse<PostsResult>> Queue(int offset, int? limit = null);
        Task<ApiResponse<PostsResult>> Drafts();
        Task<ApiResponse<PostsResult>> Drafts(ulong beforeId);

        Task<ApiResponse<GetPostResult>> Get(ulong id);

        Task<ApiResponse<bool>> Reblog(Post post, string comment);

        Task<ApiResponse<PostInformation>> Create(CreatePostRequest request, Dictionary<string,Stream> mediaStreams = null);
        Task<ApiResponse<PostInformation>> Edit(ulong postId, CreatePostRequest request, Dictionary<string, Stream> mediaStreams = null);

        Uri AvatarUri(int size);
    }
}
