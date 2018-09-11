using System;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models
{
    public class ReblogPostData:IAvatar
    {
        [JsonProperty("reblogged_from_name")]
        public string RebloggedFrom { get; set; }

        [JsonProperty("reblogged_from_url")]
        public Uri RebloggedUri { get; set; }

        [JsonProperty("reblogged_from_following")]
        public bool ReblogFollowing { get; set; }

        [JsonProperty("reblogged_from_id")]
        public long ReblogPostId { get; set; }

        [JsonIgnore] public string BlogName => RebloggedUri.Host;
    }
}
