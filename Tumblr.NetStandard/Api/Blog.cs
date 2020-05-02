using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Tumblr.NetStandard.Conversion;

namespace Tumblr.NetStandard.Api
{
    public class Blog
    {
        [JsonProperty("uuid")]
        public string UUID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("ask")]
        public bool IsAskEnabled { get; set; }

        [JsonProperty("ask_anon")]
        public bool IsAnonymousAskEnabled { get; set; }

        [JsonProperty("ask_page_title",NullValueHandling = NullValueHandling.Ignore)]
        public string AskPageTitle { get; set; }

        [JsonProperty("can_chat")]
        public bool CanChat { get; set; }

        [JsonProperty("can_subscribe")]
        public bool CanSubscribe { get; set; }

        [JsonProperty("updated"),JsonConverter(typeof(EpochDateTimeHandler))]
        public DateTime Updated { get; set; }

        [JsonProperty("is_nsfw")]
        public bool IsNSFW { get; set; }

        [JsonProperty("posts")]
        public int Posts { get; set; }

        [JsonProperty("share_likes")]
        public bool ShareLikes { get; set; }

        [JsonProperty("subscribed")]
        public bool Subscribed { get; set; }

        [JsonProperty("total_posts")]
        public int TotalPosts { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> Other { get; set; }
    }
}