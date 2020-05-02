using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF.LayoutBlocks
{
    public class AskLayout : LayoutBlock
    {
        public const string LayoutType = "ask";
        [JsonProperty("type")]
        public override string Type => LayoutType;

        [JsonProperty("blocks",NullValueHandling = NullValueHandling.Ignore)]
        public int[] Blocks { get; set; }

        [JsonProperty("attribution",NullValueHandling = NullValueHandling.Ignore)]
        public Attribution Attribution { get; set; }
    }
}