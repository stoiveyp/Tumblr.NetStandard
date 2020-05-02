using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF.Formatting
{
    public class Format
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }
    }
}
