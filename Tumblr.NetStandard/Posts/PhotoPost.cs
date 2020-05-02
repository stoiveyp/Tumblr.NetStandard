﻿using Newtonsoft.Json;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard.Posts
{
    public class PhotoPost:Post
    {
        public const string PostType = "photo";
        [JsonProperty("type")] public override string Type => PostType;

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("photos")]
        public Photo[] Photos { get; set; }
    }
}
