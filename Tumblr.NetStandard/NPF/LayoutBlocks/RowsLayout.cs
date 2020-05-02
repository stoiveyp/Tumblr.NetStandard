using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF.LayoutBlocks
{
    public class RowsLayout : LayoutBlock
    {
        public const string LayoutType = "rows";
        [JsonProperty("type")]
        public override string Type => LayoutType;

        [JsonProperty("display")]
        public Row[] Display { get; set; }
    }
}