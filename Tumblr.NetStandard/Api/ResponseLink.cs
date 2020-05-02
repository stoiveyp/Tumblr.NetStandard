﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Api
{
    public class ResponseLink
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("href",NullValueHandling = NullValueHandling.Ignore)]
        public Uri Href { get; set; }

        [JsonProperty("method",NullValueHandling = NullValueHandling.Ignore)]
        public string Method { get; set; }

        [JsonProperty("query_params",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,object> QueryParams { get; set; }
    }
}