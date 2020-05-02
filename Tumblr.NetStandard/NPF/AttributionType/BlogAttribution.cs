using Newtonsoft.Json;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard.NPF.AttributionType
{
    public class BlogAttribution : Attribution
    {
        public const string AttributionType = "blog";

        [JsonProperty("type")]
        public override string Type => AttributionType;

        [JsonProperty("url",NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("blog")]
        public ShortBlogInfo Blog { get; set; }
    }
}