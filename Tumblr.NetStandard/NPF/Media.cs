using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF
{
    public class Media
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("type",NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("width",NullValueHandling = NullValueHandling.Ignore)]
        public int? Width { get; set; }

        [JsonProperty("height",NullValueHandling = NullValueHandling.Ignore)]
        public int? Height { get; set; }

        [JsonProperty("original_dimensions_missing",NullValueHandling = NullValueHandling.Ignore)]
        public bool? OriginalDimensionsMissing { get; set; }

        [JsonProperty("cropped",NullValueHandling = NullValueHandling.Ignore)]
        public bool? Cropped { get; set; }

        [JsonProperty("has_original_dimensions",NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasOriginalDimensions { get; set; }

        [JsonProperty("poster",NullValueHandling = NullValueHandling.Ignore)]
        public Media Poster { get; set; }

        [JsonProperty("media_key",NullValueHandling = NullValueHandling.Ignore)]
        public string MediaKey { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }
    }
}
