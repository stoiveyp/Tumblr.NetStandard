using System;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Posts
{
    public class SizedPhoto
    {
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("url")]
        public Uri Location{ get; set; }
    }
}