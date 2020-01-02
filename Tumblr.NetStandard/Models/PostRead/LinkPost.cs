using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.PostRead
{
    public class LinkPost
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
