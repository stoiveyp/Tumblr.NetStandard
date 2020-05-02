using System;
using Newtonsoft.Json;
using Tumblr.NetStandard.Conversion;

namespace Tumblr.NetStandard.Api
{
    public class Follower : IAvatar
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("following")]
        public bool Following { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("updated"), JsonConverter(typeof(EpochDateTimeHandler))]
        public DateTime LastUpdated { get; set; }

        [JsonIgnore]
        public Uri SmallPicture => this.GetAvatar(AvatarSize.Small);

        [JsonIgnore]
        public string BlogName => Url.Host;
    }
}
