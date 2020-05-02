using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Tumblr.NetStandard.Conversion;
using Tumblr.NetStandard.NPF;

namespace Tumblr.NetStandard.Api
{
    [JsonConverter(typeof(PostConverter))]
    public abstract class Post:IAvatar
    {
        [JsonProperty("type")]
        public abstract string Type { get; }

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

        [JsonProperty("note_count", NullValueHandling = NullValueHandling.Ignore)]
        public int NoteCount { get; set; }

        [JsonProperty("liked", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Liked { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("post_url")]
        public Uri PostLink { get; set; }

        [JsonProperty("short_url")]
        public Uri ShortUrl { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        [JsonIgnore] public string BlogName => PostLink.Host;

        [JsonProperty("notes", NullValueHandling = NullValueHandling.Ignore)]
        public Note[] Notes { get; set; }

        [JsonProperty("display_avatar")]
        public bool DisplayAvatar { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; }

        [JsonIgnore] string IAvatar.BlogName => BlogName;
    }
}
