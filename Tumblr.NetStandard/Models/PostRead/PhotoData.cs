using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.PostRead
{
    public class PhotoData
    {
        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("photos")]
        public List<Photo> Photos { get; set; }
    }
}