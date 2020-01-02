using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.PostRead
{
    public class PhotoPost:Post
    {
        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("photos")]
        public Photo[] Photos { get; set; }
    }
}
