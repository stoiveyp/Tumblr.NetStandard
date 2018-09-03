using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.CallResult
{
    public class BlogPostResult
    {
        [JsonProperty("blog")]
        public BlogBasics Blog { get; set; }

        [JsonProperty("posts")]
        public Post[] Posts { get; set; }

        [JsonProperty("total_posts")]
        public long TotalPosts { get; set; }
    }
}
