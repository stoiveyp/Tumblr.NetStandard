using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Tumblr.NetStandard.Conversion;

namespace Tumblr.NetStandard.NPF
{
    [JsonConverter(typeof(LayoutBlockConverter))]
    public abstract class LayoutBlock
    {
        [JsonProperty("type")]
        public abstract string Type { get; }
    }
}
