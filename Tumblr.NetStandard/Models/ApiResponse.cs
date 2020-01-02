using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models
{
    public class ApiResponse<T>
    {
        [JsonIgnore]
        public bool Success { get; set; } = true;

        [JsonProperty("meta")]
        public ResponseMetaData Meta { get; set; }

        [JsonProperty("response")]
        public T Response { get; set; }
    }
}
