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

        [JsonProperty("notes", NullValueHandling = NullValueHandling.Ignore)]
        public Note[] Notes { get; set; }

        [JsonProperty("display_avatar")]
        public bool DisplayAvatar { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; }

        [JsonIgnore] string IAvatar.BlogName => BlogName;

        [JsonProperty("original_type",NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalType { get; set; }

        [JsonProperty("blog_name",NullValueHandling = NullValueHandling.Ignore)]
        public string BlogName { get; set; }

        [JsonProperty("id_string",NullValueHandling = NullValueHandling.Ignore)]
        public string IdString { get; set; }

        [JsonProperty("slug",NullValueHandling = NullValueHandling.Ignore)]
        public string Slug { get; set; }

        [JsonProperty("summary",NullValueHandling = NullValueHandling.Ignore)]
        public string Summary { get; set; }

        [JsonProperty("should_open_in_legacy",NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShouldOpenInLegacy { get; set; }

        [JsonProperty("recommended_source",NullValueHandling = NullValueHandling.Ignore)]
        public string RecommendedSource { get; set; }

        [JsonProperty("recommended_color",NullValueHandling = NullValueHandling.Ignore)]
        public string RecommendedColor { get; set; }

        [JsonProperty("reblogged_from_id",NullValueHandling = NullValueHandling.Ignore)]
        public string RebloggedFromId { get; set; }

        [JsonProperty("reblogged_from_url",NullValueHandling = NullValueHandling.Ignore)]
        public string RebloggedFromUrl { get; set; }

        [JsonProperty("reblogged_from_title",NullValueHandling = NullValueHandling.Ignore)]
        public string RebloggedFromTitle { get; set; }

        [JsonProperty("reblogged_from_uuid",NullValueHandling = NullValueHandling.Ignore)]
        public string RebloggedFromUUID { get; set; }

        [JsonProperty("reblogged_from_can_message",NullValueHandling = NullValueHandling.Ignore)]
        public bool? RebloggedFromCanMessage { get; set; }

        [JsonProperty("reblogged_root_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RebloggedRootId { get; set; }

        [JsonProperty("reblogged_root_url", NullValueHandling = NullValueHandling.Ignore)]
        public string RebloggedRootUrl { get; set; }

        [JsonProperty("reblogged_root_title", NullValueHandling = NullValueHandling.Ignore)]
        public string RebloggedRootTitle { get; set; }

        [JsonProperty("reblogged_root_uuid", NullValueHandling = NullValueHandling.Ignore)]
        public string RebloggedRootUUID { get; set; }

        [JsonProperty("reblogged_root_can_message", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RebloggedRootCanMessage { get; set; }

        [JsonProperty("can_like",NullValueHandling = NullValueHandling.Ignore)]
        public bool? CanLike { get; set; }

        [JsonProperty("can_reblog",NullValueHandling = NullValueHandling.Ignore)]
        public bool? CanReblog { get; set; }

        [JsonProperty("can_send_in_message",NullValueHandling = NullValueHandling.Ignore)]
        public bool? CanSendInMessage { get; set; }

        [JsonProperty("can_reply",NullValueHandling = NullValueHandling.Ignore)]
        public bool? CanReply { get; set; }
    }
}
