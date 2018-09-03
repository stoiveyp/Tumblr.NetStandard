using System.Threading.Tasks;
using Tumblr.NetStandard;

namespace Tumblr.NetStandard
{
    public interface ITumblrLogin
    {
        Task<TumblrCredentials> Login();
    }
}