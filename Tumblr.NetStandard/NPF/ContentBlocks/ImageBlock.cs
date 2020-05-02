using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF.ContentBlocks
{
    public class ImageBlock : ContentBlock
    {
        public const string BlockType = "image";
        [JsonProperty("type")]
        public override string Type => BlockType;

        [JsonProperty("media")]
        public Media[] Media { get; set; }

        [JsonProperty("alt_text",NullValueHandling = NullValueHandling.Ignore)]
        public string AltText { get; set; }

        [JsonProperty("feedback_token",NullValueHandling = NullValueHandling.Ignore)]
        public string FeedbackToken { get; set; }

        [JsonProperty("colors",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,string> Colors { get; set; }
    }
}