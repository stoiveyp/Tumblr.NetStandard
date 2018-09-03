using System;
using System.Linq;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models
{
    public class Follower : IAvatar
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("following")]
        public bool Following { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("updated")]
        public DateTime LastUpdated { get; set; }

        public Uri SmallPicture => this.GetAvatar(AvatarSize.Small);

        public string BlogName => Url.Host;
    }
}
