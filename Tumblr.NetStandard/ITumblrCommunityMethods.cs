using System.Threading.Tasks;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard
{
    public interface ITumblrCommunityMethods
    {
        Task<ApiResponse<Community[]>> Joined();
        Task<ApiResponse<Community>> Get(string context = null);

        Task<ApiResponse<Community>> Update(UpdateCommunityRequest request);
    }
}