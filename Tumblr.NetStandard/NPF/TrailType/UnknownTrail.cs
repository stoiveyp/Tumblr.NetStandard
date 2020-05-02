using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF.TrailType
{
    public class UnknownTrail:Trail
    {
        public UnknownTrail(string type)
        {
            Type = type;
        }

        public override string Type { get; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; }
    }
}
