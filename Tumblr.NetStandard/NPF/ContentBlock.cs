using Newtonsoft.Json;
using Tumblr.NetStandard.Conversion;

namespace Tumblr.NetStandard.NPF
{
    [JsonConverter(typeof(ContentBlockConverter))]
    public abstract class ContentBlock
    {
        [JsonProperty("type")]
        public abstract string Type { get; }

        [JsonProperty("attribution", NullValueHandling = NullValueHandling.Ignore)]
        public Attribution Attribution { get; set; }
    }
}
