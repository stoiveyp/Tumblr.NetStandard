using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF.Formatting
{
    public class Link : Format
    {
        public const string FormattingType = "link";

        [JsonProperty("type")]
        public string Type => FormattingType;

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}