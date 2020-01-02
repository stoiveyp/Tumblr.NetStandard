
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Tumblr.NetStandard.Conversion;

namespace Tumblr.NetStandard.Models
{
    [JsonConverter(typeof(PostConverter))]
    public class Post: IAvatar
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("date"), JsonConverter(typeof(EpochDateTimeHandler))]
        public DateTime Date { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp => Date;

        [JsonProperty("reblog_key")]
        public string ReblogKey { get; set; }

        [JsonProperty("blog_name")]
        public string Name { get; set; }

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

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonIgnore]
        public string SafeSlug => Slug.Replace('-', ' ');

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonIgnore] public string BlogName => PostLink.Host;

        [JsonProperty("notes")]
        public Note[] Notes { get; set; }

        [JsonProperty("reblogged_from_name", NullValueHandling = NullValueHandling.Ignore)]
        public string RebloggedFrom { get; set; }

        [JsonProperty("reblogged_from_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri RebloggedUri { get; set; }

        [JsonProperty("reblogged_from_following", NullValueHandling = NullValueHandling.Ignore)]
        public bool ReblogFollowing { get; set; }

        [JsonProperty("reblogged_from_id", NullValueHandling = NullValueHandling.Ignore)]
        public long ReblogPostId { get; set; }
    }
}
