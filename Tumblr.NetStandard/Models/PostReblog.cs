using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models
{
    public class PostReblog
    {
        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("tree_html")]
        public string TreeHtml { get; set; }
    }
}