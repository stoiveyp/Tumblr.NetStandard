using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.PostRead
{
    public class QuotePost:Post
    {
        [JsonProperty("text")]
        public string Quote { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }
}
