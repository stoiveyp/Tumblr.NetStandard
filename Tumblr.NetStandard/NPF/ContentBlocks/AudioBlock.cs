using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF.ContentBlocks
{
    public class AudioBlock : ContentBlock
    {
        public const string BlockType = "audio";
        [JsonProperty("type")]
        public override string Type => BlockType;

        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("url",NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("media",NullValueHandling = NullValueHandling.Ignore)]
        public Media Media { get; set; }

        [JsonProperty("poster",NullValueHandling = NullValueHandling.Ignore)]
        public Media Poster { get; set; }

        [JsonProperty("title",NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("artist",NullValueHandling = NullValueHandling.Ignore)]
        public string Artist { get; set; }

        [JsonProperty("album",NullValueHandling = NullValueHandling.Ignore)]
        public string Album { get; set; }

        [JsonProperty("embed_html",NullValueHandling = NullValueHandling.Ignore)]
        public string EmbedHtml { get; set; }

        [JsonProperty("embed_url",NullValueHandling = NullValueHandling.Ignore)]
        public string EmbedUrl { get; set; }

        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,object> Metadata { get; set; }
    }
}