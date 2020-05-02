using Newtonsoft.Json;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard.Notes
{
    public class ReblogNote:Note
    {
        [JsonProperty("added_text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("post_id")]
        public string PostId { get; set; }

        [JsonProperty("reblog_parent_blog_name")]
        public string ReblogParentBlogName { get; set; }
    }
}
