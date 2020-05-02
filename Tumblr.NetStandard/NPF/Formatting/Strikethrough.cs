﻿using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF.Formatting
{
    public class Strikethrough : Format
    {
        public const string FormattingType = "strikethrough";

        [JsonProperty("type")]
        public override string Type => FormattingType;
    }
}