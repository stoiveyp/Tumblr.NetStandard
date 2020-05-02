using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Tumblr.NetStandard.Conversion;

namespace Tumblr.NetStandard.NPF
{
    [JsonConverter(typeof(AttributionTypeConverter))]
    public abstract class Attribution
    {
        [JsonProperty("type",NullValueHandling = NullValueHandling.Ignore)]
        public abstract string Type { get; }
    }
}
