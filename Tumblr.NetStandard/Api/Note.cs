using System;
using Newtonsoft.Json;
using Tumblr.NetStandard.Conversion;

namespace Tumblr.NetStandard.Api
{
    [JsonConverter(typeof(NoteConverter))]
    public class Note
    {
        [JsonProperty("blog_name")]
        public string BlogName { get; set; }

        [JsonProperty("blog_url")]
        public Uri BlogUrl { get; set; }

        [JsonProperty("blog_uuid")]
        public string BlogUuid { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("timestamp"), JsonConverter(typeof(EpochDateTimeHandler))]
        public DateTime Timestamp { get; set; }

        [JsonProperty("followed")]
        public bool Followed { get; set; }

        [JsonProperty("avatar_shape")]
        public string AvatarShape { get; set; }

        [JsonProperty("can_block",NullValueHandling = NullValueHandling.Ignore)]
        public bool? CanBlock { get; set; }
    }
}
