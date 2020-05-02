using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF.AttributionType
{
    public class AppAttribution : Attribution
    {
        public const string AttributionType = "app";

        [JsonProperty("type")]
        public override string Type => AttributionType;

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("app_name",NullValueHandling = NullValueHandling.Ignore)]
        public string AppName { get; set; }

        [JsonProperty("display_text",NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayText { get; set; }

        [JsonProperty("logo",NullValueHandling = NullValueHandling.Ignore)]
        public Media Logo { get; set; }
    }
}