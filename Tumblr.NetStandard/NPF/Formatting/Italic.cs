﻿using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF.Formatting
{
    public class Italic : Format
    {
        public const string FormattingType = "italic";

        [JsonProperty("type")]
        public override string Type => FormattingType;
    }
}