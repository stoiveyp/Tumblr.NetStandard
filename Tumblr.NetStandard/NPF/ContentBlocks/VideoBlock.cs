using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF.ContentBlocks
{
    public class VideoBlock : ContentBlock
    {
        public const string BlockType = "video";
        [JsonProperty("type")]
        public override string Type => BlockType;

        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
        public Media Media { get; set; }

        [JsonProperty("poster", NullValueHandling = NullValueHandling.Ignore)]
        public Media[] Poster { get; set; }

        [JsonProperty("embed_html", NullValueHandling = NullValueHandling.Ignore)]
        public string EmbedHtml { get; set; }

        [JsonProperty("embed_iframe",NullValueHandling = NullValueHandling.Ignore)]
        public IFrame EmbedIFrame { get; set; }

        [JsonProperty("embed_url", NullValueHandling = NullValueHandling.Ignore)]
        public string EmbedUrl { get; set; }

        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Metadata { get; set; }

        [JsonProperty("can_autoplay_on_cellular",NullValueHandling = NullValueHandling.Ignore)]
        public bool? CanAutoplayOnCellular { get; set; }
    }
}