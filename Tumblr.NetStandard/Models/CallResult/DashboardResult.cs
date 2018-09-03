using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.CallResult
{
    public class DashboardResult
    {
        [JsonProperty("posts")]
        public Post[] Posts { get; set; }
    }
}