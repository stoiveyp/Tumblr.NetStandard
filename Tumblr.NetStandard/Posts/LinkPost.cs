using Newtonsoft.Json;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard.Posts
{
    public class LinkPost:Post
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("photos")]
        public Photo[] Photos { get; set; }

        [JsonIgnore]
        public string LinkText => string.IsNullOrWhiteSpace(Title) ? Url : Title;
    }
}
