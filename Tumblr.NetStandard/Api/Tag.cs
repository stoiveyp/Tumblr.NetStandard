using System;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Api
{
    public class Tag
    {
        [JsonProperty("tag",NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("thumb_url",NullValueHandling = NullValueHandling.Ignore)]
        public Uri ThumbnailUri { get; set; }

        [JsonProperty("is_tracked",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsTracked { get; set; }

        [JsonProperty("featured",NullValueHandling = NullValueHandling.Ignore)]
        public bool? Featured { get; set; }
    }
}
