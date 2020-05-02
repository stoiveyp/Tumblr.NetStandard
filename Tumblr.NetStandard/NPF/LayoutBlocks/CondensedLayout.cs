using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF.LayoutBlocks
{
    public class CondensedLayout : LayoutBlock
    {
        public const string LayoutType = "condensed";
        [JsonProperty("type")]
        public override string Type => LayoutType;

        [JsonProperty("truncate_after",NullValueHandling = NullValueHandling.Ignore)]
        public int? TruncateAfter { get; set; }

        [JsonProperty("blocks",NullValueHandling = NullValueHandling.Ignore)]
        public int[] Blocks { get; set; }
    }
}