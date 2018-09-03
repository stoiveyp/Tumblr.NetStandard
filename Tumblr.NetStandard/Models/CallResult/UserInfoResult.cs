using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.CallResult
{
    public class UserInfoResult
    {
        [JsonProperty("user")]
        public UserInfo User { get; set; }
    }
}
