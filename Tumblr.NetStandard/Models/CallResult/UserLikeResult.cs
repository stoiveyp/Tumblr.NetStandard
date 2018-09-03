using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.CallResult
{
    public class UserLikeResult
    {
        [JsonProperty("liked_posts")]
        public List<Post> Posts { get; set; }

        [JsonProperty("liked_count")]
        public int TotalCount { get; set; }
    }
}
