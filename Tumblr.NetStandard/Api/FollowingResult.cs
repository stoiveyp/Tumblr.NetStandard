using Newtonsoft.Json;

namespace Tumblr.NetStandard.Api
{
    public class FollowingResult
    {
        [JsonProperty("total_blogs")]
        public int TotalFollowing { get; set; }

        [JsonProperty("blogs", NullValueHandling = NullValueHandling.Ignore)]
        public ShortBlogInfo[] Following { get; set; }
    }
}
