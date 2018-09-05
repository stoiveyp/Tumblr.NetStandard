using System.Threading.Tasks;
using Tumblr.NetStandard.Models;
using Tumblr.NetStandard.Models.CallResult;

namespace Tumblr.NetStandard
{
    public interface ITumblrBlogMethods
    {
        Task<ApiResponse<BlogPostResult>> Posts();
    }
}
