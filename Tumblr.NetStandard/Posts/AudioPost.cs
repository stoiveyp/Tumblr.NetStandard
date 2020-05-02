using System;
using Newtonsoft.Json;
using Tumblr.NetStandard.Api;
using Tumblr.NetStandard.NPF;

namespace Tumblr.NetStandard.Posts
{
    public class AudioPost : Post
    {
        public const string PostType = "audio";
        [JsonProperty("type")] public override string Type => PostType;

        [JsonProperty("album_art")]
        public Uri AlbumArt { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("audio_url")]
        public Uri AudioUrl { get; set; }

        [JsonProperty("permalink_url")]
        public Uri Permalink { get; set; }

        [JsonProperty("source_url")]
        public Uri SourceUrl { get; set; }

        [JsonProperty("html5_enabled")]
        public bool IsHtml5 { get; set; }
        [JsonIgnore]
        public Uri PreferredUrl => AudioUrl ?? Permalink ?? SourceUrl ?? PostLink;

        [JsonProperty("trail", NullValueHandling = NullValueHandling.Ignore)]
        public LegacyTrail[] Trail { get; set; }
    }
}
