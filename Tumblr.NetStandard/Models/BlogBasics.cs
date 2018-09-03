using System;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models
{
    public class BlogBasics
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("ask")]
        public bool IsAskEnabled { get; set; }

        [JsonProperty("ask_anon")]
        public bool IsAnonymousAskEnabled { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        [JsonProperty("is_nsfw")]
        public bool NotSafe { get; set; }
    }
}