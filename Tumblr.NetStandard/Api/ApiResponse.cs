using Newtonsoft.Json;

namespace Tumblr.NetStandard.Api
{
    public class ApiResponse<T>
    {
        [JsonIgnore]
        public bool Success { get; set; } = true;

        [JsonProperty("meta")]
        public ResponseMetaData Meta { get; set; }

        [JsonProperty("response")]
        public T Response { get; set; }

        [JsonProperty("errors",NullValueHandling = NullValueHandling.Ignore)]
        public Error[] Errors { get; set; }
    }
}
