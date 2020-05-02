using Newtonsoft.Json;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard.Posts
{
    public class TextPost:Post
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("body", NullValueHandling = NullValueHandling.Ignore)]
        public string Body { get; set; }
    }
}
