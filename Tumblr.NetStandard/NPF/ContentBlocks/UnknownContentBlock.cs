using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF.ContentBlocks
{
    public class UnknownContentBlock:ContentBlock
    {
        public override string Type { get; }

        public UnknownContentBlock(string type)
        {
            Type = type;
        }

        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }
    }
}
