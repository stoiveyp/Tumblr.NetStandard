using Newtonsoft.Json;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard.NPF.Formatting
{
    public class Mention : Format
    {
        public const string FormattingType = "mention";

        [JsonProperty("type")]
        public override string Type => FormattingType;

        [JsonProperty("blog")]
        public BlogIdentifier Blog { get; set; }
    }
}