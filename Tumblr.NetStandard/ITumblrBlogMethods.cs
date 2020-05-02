using System.Threading.Tasks;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard
{
    public interface ITumblrBlogMethods
    {
        Task<ApiResponse<BlogPostResult>> Posts();
        Task<ApiResponse<BlogPostResult>> Posts(int offset, int limit);
    }
}
