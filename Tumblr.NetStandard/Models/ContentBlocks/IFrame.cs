using System;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.ContentBlocks
{
    public class IFrame
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }
}