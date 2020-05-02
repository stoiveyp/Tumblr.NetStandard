using System;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Api
{
    public class BlogIdentifier
    {
        [JsonProperty("uuid")]
        public string UUID { get; set; }

        [JsonProperty("name",NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }
    }
}