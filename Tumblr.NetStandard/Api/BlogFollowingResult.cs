using Newtonsoft.Json;

namespace Tumblr.NetStandard.Api
{
    public class BlogFollowingResult
    {
        [JsonProperty("total_blogs")]
        public int TotalUsers { get; set; }

        [JsonProperty("blogs", NullValueHandling = NullValueHandling.Ignore)]
        public ShortBlogInfo[] Blogs { get; set; }
    }
}