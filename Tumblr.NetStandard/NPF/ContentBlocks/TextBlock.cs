using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Tumblr.NetStandard.NPF.ContentBlocks
{
    public class TextBlock:ContentBlock
    {
        public const string BlockType = "text";
        [JsonProperty("type")]
        public override string Type => BlockType;

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("subtype",NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public TextSubtype Subtype { get; set; }

        [JsonProperty("formatting", NullValueHandling = NullValueHandling.Ignore)]
        public Format[] Formatting { get; set; }
    }
}
