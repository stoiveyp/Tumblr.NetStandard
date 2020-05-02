using Newtonsoft.Json;

namespace Tumblr.NetStandard.Api
{
    public class PostsResult
    {
        [JsonProperty("posts")]
        public Post[] Posts { get; set; }
    }
}