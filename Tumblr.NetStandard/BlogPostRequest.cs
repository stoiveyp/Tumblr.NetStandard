using Newtonsoft.Json;

namespace Tumblr.NetStandard
{
    public class BlogPostRequest
    {
        [JsonProperty("type",NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("tag",NullValueHandling = NullValueHandling.Ignore)]
        public string Tag { get; set; }

        [JsonProperty("limit",NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }

        [JsonProperty("offset",NullValueHandling = NullValueHandling.Ignore)]
        public int? Offset { get; set; }

        [JsonProperty("before",NullValueHandling = NullValueHandling.Ignore)]
        public ulong? Before { get; set; }
    }
}