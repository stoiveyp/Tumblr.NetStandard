using Newtonsoft.Json;

namespace Tumblr.NetStandard.Api
{
    public class DashboardResult
    {
        [JsonProperty("posts")]
        public Post[] Posts { get; set; }
    }
}