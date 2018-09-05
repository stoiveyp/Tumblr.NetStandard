using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tumblr.NetStandard.Models;

namespace Tumblr.NetStandard
{
    public interface ITumblrPostMethods
    {
        Task<ApiResponse<bool>> Like();
        Task<ApiResponse<bool>> Unlike();
    }
}
