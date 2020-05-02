using Newtonsoft.Json;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard.Posts
{
    public class PhotoPost:Post
    {
        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("photos")]
        public Photo[] Photos { get; set; }
    }
}
