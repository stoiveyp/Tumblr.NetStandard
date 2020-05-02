using System;
using System.Linq;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Posts
{
    public class Photo
    {
        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("original_size")]
        public SizedPhoto Original { get; set; }

        [JsonProperty("alt_sizes", NullValueHandling = NullValueHandling.Ignore)]
        public SizedPhoto[] Sizes { get; set; }

        [JsonIgnore]
        public Uri Thumbnail { get { return Sizes?.OrderBy(p => p.Width).FirstOrDefault()?.Location; } }
    }
}