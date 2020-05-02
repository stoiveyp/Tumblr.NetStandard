using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF
{
    public class PostInformation
    {
        [JsonProperty("id",NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }
    }
}