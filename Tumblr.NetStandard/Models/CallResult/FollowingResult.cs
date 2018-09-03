using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.CallResult
{
    public class FollowingResult
    {
        [JsonProperty("total_blogs")]
        public int TotalFollowing { get; set; }

        [JsonProperty("blogs")]
        public List<Follower> Following { get; set; }
    }
}
