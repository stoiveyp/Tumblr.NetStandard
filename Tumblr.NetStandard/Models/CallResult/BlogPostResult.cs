using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.CallResult
{
    public class BlogPostResult
    {
        [JsonProperty("_links", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,ResponseLink> Links { get; set; }

        [JsonProperty("blog")]
        public Blog Blog { get; set; }

        [JsonProperty("posts")]
        public Post[] Posts { get; set; }

        [JsonProperty("total_posts")]
        public long TotalPosts { get; set; }
    }
}
