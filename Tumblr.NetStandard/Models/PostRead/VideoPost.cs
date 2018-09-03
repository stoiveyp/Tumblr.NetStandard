using System;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.PostRead
{
    public class VideoPost : Post<VideoData>
    {
        [JsonIgnore]
        public Uri PreferredUrl => Data.VideoUrl ?? Data.Permalink ?? Data.SourceUrl ?? Common.PostLink;
    }
}
