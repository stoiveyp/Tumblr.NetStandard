using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF.AttributionType
{
    public class LinkAttribution : Attribution
    {
        public const string AttributionType = "link";

        [JsonProperty("type")]
        public override string Type => AttributionType;

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}