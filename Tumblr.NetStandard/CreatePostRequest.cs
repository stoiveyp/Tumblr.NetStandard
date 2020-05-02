using System;
using Newtonsoft.Json;
using Tumblr.NetStandard.Api;
using Tumblr.NetStandard.NPF;

namespace Tumblr.NetStandard
{
    public class CreatePostRequest
    {
        [JsonProperty("content")]
        public ContentBlock[] Content { get; set; }

        [JsonProperty("layout",NullValueHandling = NullValueHandling.Ignore)]
        public LayoutBlock[] Layout { get; set; }

        [JsonProperty("state",NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        [JsonProperty("publish_on",NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? PublishOn { get; set; }

        [JsonProperty("tags",NullValueHandling = NullValueHandling.Ignore)]
        public string Tags { get; set; }

        [JsonProperty("source_url",NullValueHandling = NullValueHandling.Ignore)]
        public string SourceUrl { get; set; }

        [JsonProperty("send_to_twitter",NullValueHandling = NullValueHandling.Ignore)]
        public bool? SendToTwitter { get; set; }

        [JsonProperty("send_to_facebook",NullValueHandling = NullValueHandling.Ignore)]
        public bool? SendToFacebook { get; set; }

        [JsonProperty("is_private",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPrivate { get; set; }

        [JsonProperty("parent_tumblelog_uuid")]
        public string ParentBlogUuid { get; set; }

        [JsonProperty("parent_post_id")]
        public ulong ParentPostId { get; set; }

        [JsonProperty("reblog_key")]
        public string ReblogKey { get; set; }

        [JsonProperty("hide_trail", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HideTrail { get; set; }

        public CreatePostRequest FromPost(Post post)
        {
            return new CreatePostRequest
            {
                ReblogKey = post.ReblogKey,
                ParentPostId = post.Id,
                ParentBlogUuid = post.Blog.UUID
            };
        }
    }
}