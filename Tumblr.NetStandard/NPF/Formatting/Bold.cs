using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF.Formatting
{
    public class Bold : Format
    {
        public const string FormattingType = "bold";

        [JsonProperty("type")]
        public string Type => FormattingType;
    }
}