using Newtonsoft.Json;

namespace Tumblr.NetStandard.Api
{
    public class Error
    {
        [JsonProperty("title",NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("code",NullValueHandling = NullValueHandling.Ignore)]
        public int Code { get; set; }
    }
}