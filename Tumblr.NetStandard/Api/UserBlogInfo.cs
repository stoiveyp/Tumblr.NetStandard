using System;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Api
{
    public class UserBlogInfo:IAvatar
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public Uri Uri { get; set; }

        [JsonProperty("primary")]
        public bool Primary { get; set; }

        [JsonProperty("followers")]
        public int Followers { get; set; }

        public string BlogName => Uri.Host;
    }
}
