using System;
using System.Threading.Tasks;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard
{
    public interface ITumblrClient
    {
        Action<string> OnError { get; set; }

        ITumblrUserMethods User { get; }

        ITumblrBlogMethods ForBlog(string blogName);

        ITumblrPostMethods ForPost(Post post);

        ITumblrPostMethods ForPost(ulong id, string reblogKey);

        Task<ApiResponse<Post[]>> Tagged(string tag);

        bool UseNpf { get; set; }
    }
}