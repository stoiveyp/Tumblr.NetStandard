using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Tumblr.NetStandard.Conversion;

namespace Tumblr.NetStandard.Api
{
    public class Blog:IAvatar
    {
        [JsonProperty("uuid", NullValueHandling = NullValueHandling.Ignore)]
        public string UUID { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("ask", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsAskEnabled { get; set; }

        [JsonProperty("ask_anon", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsAnonymousAskEnabled { get; set; }

        [JsonProperty("ask_page_title",NullValueHandling = NullValueHandling.Ignore)]
        public string AskPageTitle { get; set; }

        [JsonProperty("can_chat", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CanChat { get; set; }

        [JsonProperty("can_subscribe", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CanSubscribe { get; set; }

        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore),JsonConverter(typeof(EpochDateTimeHandler))]
        public DateTime? Updated { get; set; }

        [JsonProperty("is_nsfw", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsNSFW { get; set; }

        [JsonProperty("posts", NullValueHandling = NullValueHandling.Ignore)]
        public int? Posts { get; set; }

        [JsonProperty("share_likes", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShareLikes { get; set; }

        [JsonProperty("subscribed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Subscribed { get; set; }

        [JsonProperty("total_posts", NullValueHandling = NullValueHandling.Ignore)]
        public int? TotalPosts { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; }

        [JsonIgnore] string IAvatar.BlogName => Name;
    }
}