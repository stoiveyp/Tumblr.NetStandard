using System;
using System.Threading.Tasks;
using Tumblr.NetStandard.Models;
using Tumblr.NetStandard.Models.CallResult;

namespace Tumblr.NetStandard
{
    public interface ITumblrClient
    {
        Action<string> OnError { get; set; }

        ITumblrUserMethods User { get; }

        ITumblrBlogMethods ForBlog(string blogName);

        ITumblrPostMethods ForPost(Post post);

        ITumblrPostMethods ForPost(long id, string reblogKey);

        Task<ApiResponse<Post[]>> Tagged(string tag);
    }
}