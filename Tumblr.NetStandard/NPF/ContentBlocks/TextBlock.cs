using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Tumblr.NetStandard.NPF.ContentBlocks
{
    public class TextBlock:ContentBlock
    {
        public const string BlockType = "text";
        public override string Type => BlockType;

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("subtype",NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public TextSubtype Subtype { get; set; }
    }
}
