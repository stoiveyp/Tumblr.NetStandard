using Newtonsoft.Json;

namespace Tumblr.NetStandard.Api
{
    public class UserLikeResult
    {
        [JsonProperty("liked_posts", NullValueHandling = NullValueHandling.Ignore)]
        public Post[] Posts { get; set; }

        [JsonProperty("liked_count")]
        public int TotalCount { get; set; }
    }
}
