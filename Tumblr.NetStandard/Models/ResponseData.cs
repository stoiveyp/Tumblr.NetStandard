using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models
{
    public class ResponseData
    {
        [JsonProperty("_links",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,ResponseLink> Links { get; set; }
    }
}