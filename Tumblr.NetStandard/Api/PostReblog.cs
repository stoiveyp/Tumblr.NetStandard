using Newtonsoft.Json;

namespace Tumblr.NetStandard.Api
{
    public class PostReblog
    {
        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("tree_html")]
        public string TreeHtml { get; set; }
    }
}