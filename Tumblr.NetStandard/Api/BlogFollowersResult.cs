using Newtonsoft.Json;

namespace Tumblr.NetStandard.Api
{
    public class BlogFollowersResult
    {
        [JsonProperty("total_users")]
        public int TotalUsers { get; set; }

        [JsonProperty("users", NullValueHandling = NullValueHandling.Ignore)]
        public Follower[] Users { get; set; }
    }
}