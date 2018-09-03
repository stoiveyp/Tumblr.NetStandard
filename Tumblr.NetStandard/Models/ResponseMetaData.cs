using System.Net;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models
{
    public class ResponseMetaData
    {
        [JsonProperty("status")]
        public HttpStatusCode Code { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }
    }
}
