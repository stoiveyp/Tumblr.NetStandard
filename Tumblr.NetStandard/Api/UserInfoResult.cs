using Newtonsoft.Json;

namespace Tumblr.NetStandard.Api
{
    public class UserInfoResult
    {
        [JsonProperty("user")]
        public UserInfo User { get; set; }
    }
}
