using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.PostRead
{
    public class TextPost:Post
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("body", NullValueHandling = NullValueHandling.Ignore)]
        public string Body { get; set; }
    }
}
