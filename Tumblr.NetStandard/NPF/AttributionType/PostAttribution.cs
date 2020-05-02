using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard.NPF.AttributionType
{
    public class PostAttribution:Attribution
    {
        public const string AttributionType = "post";

        [JsonProperty("type")]
        public override string Type => AttributionType;

        [JsonProperty("post")]
        public PostInformation Post { get; set; }

        [JsonProperty("blog")]
        public BlogIdentifier Blog { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }
    }
}
