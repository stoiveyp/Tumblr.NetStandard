﻿using Newtonsoft.Json;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard.Posts
{
    public class QuotePost:Post
    {
        public const string PostType = "quote";
        [JsonProperty("type")] public override string Type => PostType;

        [JsonProperty("text")]
        public string Quote { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }
}
