using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Tumblr.NetStandard.NPF;

namespace Tumblr.NetStandard.Api
{
    public class GetPostResult
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id",NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("tumblelog_uuid",NullValueHandling = NullValueHandling.Ignore)]
        public string BlogUuid { get; set; }

        [JsonProperty("parent_post_id",NullValueHandling = NullValueHandling.Ignore)]
        public string ParentPostId { get; set; }

        [JsonProperty("parent_tumblelog_uuid",NullValueHandling = NullValueHandling.Ignore)]
        public string ParentBlogUuid { get; set; }

        [JsonProperty("reblog_key",NullValueHandling = NullValueHandling.Ignore)]
        public string ReblogKey { get; set; }

        [JsonProperty("content",NullValueHandling = NullValueHandling.Ignore)]
        public ContentBlock[] Content { get; set; }

        [JsonProperty("layout",NullValueHandling = NullValueHandling.Ignore)]
        public LayoutBlock[] Layout { get; set; }
    }
}
