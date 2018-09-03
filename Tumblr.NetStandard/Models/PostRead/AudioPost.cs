using System;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.PostRead
{
    public class AudioPost:Post<AudioData>
    {
        [JsonIgnore]
        public Uri PreferredUrl => Data.AudioUrl ?? Data.Permalink ?? Data.SourceUrl ?? Common.PostLink;
    }
}
