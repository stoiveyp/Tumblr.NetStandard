using System.Collections.Generic;
using Newtonsoft.Json;
using Tumblr.NetStandard.Api;
using Tumblr.NetStandard.NPF;

namespace Tumblr.NetStandard.Posts
{
    public class LegacyTrail
    {
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        [JsonProperty("content_raw",NullValueHandling = NullValueHandling.Ignore)]
        public string ContentRaw { get; set; }

        [JsonProperty("content_abstract", NullValueHandling = NullValueHandling.Ignore)]
        public string ContentAbstract { get; set; }

        [JsonProperty("layout", NullValueHandling = NullValueHandling.Ignore)]
        public LayoutBlock[] Layout { get; set; }

        [JsonProperty("blog", NullValueHandling = NullValueHandling.Ignore)]
        public Blog Blog { get; set; }

        [JsonProperty("post", NullValueHandling = NullValueHandling.Ignore)]
        public PostInformation Post { get; set; }

        [JsonProperty("broken_blog_name", NullValueHandling = NullValueHandling.Ignore)]
        public string BrokenBlogName { get; set; }

        [JsonProperty("is_current_item",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsCurrentItem { get; set; }

        [JsonProperty("is_root_item",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsRootItem { get; set; }
    }
}