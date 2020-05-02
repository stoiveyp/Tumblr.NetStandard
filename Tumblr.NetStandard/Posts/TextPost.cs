using Newtonsoft.Json;
using Tumblr.NetStandard.Api;
using Tumblr.NetStandard.NPF;

namespace Tumblr.NetStandard.Posts
{
    public class TextPost:Post
    {
        public const string PostType = "text";
        [JsonProperty("type")] public override string Type => PostType;

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("body", NullValueHandling = NullValueHandling.Ignore)]
        public string Body { get; set; }

        [JsonProperty("trail", NullValueHandling = NullValueHandling.Ignore)]
        public LegacyTrail[] Trail { get; set; }
    }
}
