using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF.AttributionType
{
    public class UnknownAttribution:Attribution
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public override string Type { get; }
        public UnknownAttribution(string type)
        {
            Type = type;
        }
    }
}
