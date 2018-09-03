using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models
{
    public class BlogDetails
    {
        [JsonProperty("admin")]
        public bool Admin { get; set; }

        [JsonProperty("posts")]
        public int Posts { get; set; }

        [JsonProperty("followers")]
        public int Followers { get; set; }

        [JsonProperty("drafts")]
        public int Drafts { get; set; }

        [JsonProperty("messages")]
        public int Messages { get; set; }

        [JsonProperty("likes")]
        public int Likes { get; set; }

        [JsonProperty("queue")]
        public int Queue { get; set; }

        [JsonProperty("followed")]
        public bool Followed { get; set; }
    }
}
