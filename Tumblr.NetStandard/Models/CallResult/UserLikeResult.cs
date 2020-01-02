using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.CallResult
{
    public class UserLikeResult
    {
        [JsonProperty("liked_posts", NullValueHandling = NullValueHandling.Ignore)]
        public Post[] Posts { get; set; }

        [JsonProperty("liked_count")]
        public int TotalCount { get; set; }
    }
}
