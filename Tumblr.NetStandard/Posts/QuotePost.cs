using Newtonsoft.Json;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard.Posts
{
    public class QuotePost:Post
    {
        [JsonProperty("text")]
        public string Quote { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }
}
