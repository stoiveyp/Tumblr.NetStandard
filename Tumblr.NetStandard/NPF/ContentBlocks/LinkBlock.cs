using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF.ContentBlocks
{
    public class LinkBlock : ContentBlock
    {
        public const string BlockType = "link";
        [JsonProperty("type")]
        public override string Type => BlockType;

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("title",NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("description",NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("author",NullValueHandling = NullValueHandling.Ignore)]
        public string Author { get; set; }

        [JsonProperty("site_name",NullValueHandling = NullValueHandling.Ignore)]
        public string SiteName { get; set; }

        [JsonProperty("display_url",NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayUrl { get; set; }

        [JsonProperty("poster",NullValueHandling = NullValueHandling.Ignore)]
        public Media[] Poster { get; set; }
    }
}