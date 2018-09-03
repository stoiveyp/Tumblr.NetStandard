using System;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.PostRead
{
    public class AudioData
    {
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
    }
}