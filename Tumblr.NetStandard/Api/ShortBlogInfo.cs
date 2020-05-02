using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Tumblr.NetStandard.Conversion;

namespace Tumblr.NetStandard.Api
{
    public class ShortBlogInfo
    {
        [JsonProperty("uuid")]
        public string UUID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("updated"),JsonConverter(typeof(EpochDateTimeHandler))]
        public DateTime Updated { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }
    }
}
