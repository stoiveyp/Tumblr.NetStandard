using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF.Formatting
{
    public class Color : Format
    {
        public const string FormattingType = "color";

        [JsonProperty("type")]
        public string Type => FormattingType;

        [JsonProperty("hex")]
        public string Hex { get; set; }
    }
}