using Newtonsoft.Json;

namespace Tumblr.NetStandard.Api
{
    public class BlogInfoResult
    {
        
        [JsonProperty("blog")]
        public Blog Blog { get; set; }
    }
}