using Newtonsoft.Json;
using Tumblr.NetStandard.Api;
using Tumblr.NetStandard.NPF;

namespace Tumblr.NetStandard.Posts
{
    public class BlocksPost:Post
    {
        public const string PostType = "blocks";
        [JsonProperty("type")] public override string Type => PostType;

        [JsonProperty("content")]
        public ContentBlock[] Content { get; set; }

        [JsonProperty("layout",NullValueHandling = NullValueHandling.Ignore)]
        public LayoutBlock[] Layout { get; set; }

        [JsonProperty("trail", NullValueHandling = NullValueHandling.Ignore)]
        public Trail[] Trail { get; set; }
    }
}
