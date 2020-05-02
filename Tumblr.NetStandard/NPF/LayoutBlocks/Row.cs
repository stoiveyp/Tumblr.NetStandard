using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF.LayoutBlocks
{
    public class Row
    {
        [JsonProperty("blocks")]
        public int[] Blocks { get; set; }

        [JsonProperty("mode",NullValueHandling = NullValueHandling.Ignore)]
        public RowMode Mode { get; set; }
    }
}