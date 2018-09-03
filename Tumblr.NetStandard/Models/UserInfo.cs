using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models
{
    public class UserInfo
    {
        [JsonProperty("following")]
        public int Following { get; set; }

        [JsonProperty("default_post_format")]
        public string PostFormat { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("likes")]
        public int Likes { get; set; }

        [JsonProperty("blogs")]
        public List<UserBlogInfo> Blogs { get; set; }
    }
}
