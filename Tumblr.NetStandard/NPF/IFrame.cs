using System;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF
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