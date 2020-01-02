using System;
using Newtonsoft.Json;
using Tumblr.NetStandard.Conversion;

namespace Tumblr.NetStandard.Models
{
    [JsonConverter(typeof(NoteConverter))]
    public class Note
    {
        [JsonProperty("blog_name")]
        public string Name { get; set; }

        [JsonProperty("blog_url")]
        public Uri Url { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("timestamp"), JsonConverter(typeof(EpochDateTimeHandler))]
        public DateTime Timestamp { get; set; }
    }
}
