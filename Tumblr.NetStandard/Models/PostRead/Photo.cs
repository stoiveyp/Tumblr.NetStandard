using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.PostRead
{
    public class Photo
    {
        [JsonProperty("original_size")]
        public SizedPhoto Original { get; set; }

        [JsonProperty("alt_sizes")]
        public List<SizedPhoto> Sizes { get; set; }

        [JsonIgnore]
        public Uri Thumbnail { get { return Sizes.OrderBy(p => p.Width).First().Location; } }
    }
}