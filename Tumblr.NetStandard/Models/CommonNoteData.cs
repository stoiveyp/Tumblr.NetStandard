using System;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models
{
    public class CommonNoteData
    {
        [JsonProperty("blog_name")]
        public string Name { get; set; }

        [JsonProperty("blog_url")]
        public Uri Url { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
