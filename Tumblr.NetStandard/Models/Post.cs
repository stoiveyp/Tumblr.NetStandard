
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Tumblr.NetStandard.Conversion;

namespace Tumblr.NetStandard.Models
{
    [JsonConverter(typeof(PostConverter))]
    public class Post
    {
        [JsonProperty("id")]
        public ulong Id { get; set; }

        [JsonProperty("blog")]
        public ShortBlogInfo Blog { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("timestamp"), JsonConverter(typeof(EpochDateTimeHandler))]
        public DateTime Timestamp { get; set; }

        [JsonProperty("reblog_key")]
        public string ReblogKey { get; set; }

        [JsonProperty("note_count")]
        public int NoteCount { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("liked")]
        public bool Liked { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("post_url")]
        public Uri PostLink { get; set; }

        [JsonProperty("short_url")]
        public Uri ShortUrl { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonIgnore] public string BlogName => PostLink.Host;

        [JsonProperty("notes")]
        public Note[] Notes { get; set; }

        [JsonProperty("display_avatar")]
        public bool DisplayAvatar { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> Other { get; set; }
    }
}
