using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF.LayoutBlocks
{
    public class UnknownLayoutBlock:LayoutBlock
    {
        public override string Type { get; }

        public UnknownLayoutBlock(string type)
        {
            Type = type;
        }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; }
    }
}
