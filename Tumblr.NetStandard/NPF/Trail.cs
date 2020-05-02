using System;
using System.Text;
using Newtonsoft.Json;
using Tumblr.NetStandard.Api;
using Tumblr.NetStandard.Conversion;

namespace Tumblr.NetStandard.NPF
{
    public class Trail
    {
        [JsonProperty("content",NullValueHandling = NullValueHandling.Ignore)]
        public ContentBlock[] Content { get; set; }

        [JsonProperty("layout",NullValueHandling = NullValueHandling.Ignore)]
        public LayoutBlock[] Layout { get; set; }

        [JsonProperty("blog",NullValueHandling = NullValueHandling.Ignore)]
        public ShortBlogInfo Blog { get; set; }

        [JsonProperty("post",NullValueHandling = NullValueHandling.Ignore)]
        public PostInformation Post { get; set; }

        [JsonProperty("broken_blog_name",NullValueHandling = NullValueHandling.Ignore)]
        public string BrokenBlogName { get; set; }
    }
}
