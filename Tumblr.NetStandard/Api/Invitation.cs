using Newtonsoft.Json;

namespace Tumblr.NetStandard.Api
{
    public class Invitation
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("sender", NullValueHandling = NullValueHandling.Ignore)]
        public ShortBlogInfo Sender { get; set; }
    }
}
