using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.PostRead
{
    public class QuoteData
    {
        [JsonProperty("text")]
        public string Quote { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }
}