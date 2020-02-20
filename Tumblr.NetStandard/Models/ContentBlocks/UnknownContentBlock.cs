﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.ContentBlocks
{
    public class UnknownContentBlock:ContentBlock
    {
        public override string Type { get; }

        public UnknownContentBlock(string type)
        {
            Type = type;
        }

        [JsonExtensionData]
        public Dictionary<string,object> Data { get; set; }
    }
}
