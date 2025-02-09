using Newtonsoft.Json;

namespace Tumblr.NetStandard.Api
{
    public class ShortCommunity
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("uuid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uuid { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("member_count", NullValueHandling = NullValueHandling.Ignore)]
        public int MemberCount { get; set; }

        [JsonProperty("mention_tag", NullValueHandling = NullValueHandling.Ignore)]
        public string MentionTag { get; set; }

        [JsonProperty("can_view", NullValueHandling = NullValueHandling.Ignore)]
        public bool CanView { get; set; }

        [JsonProperty("avatar_image", NullValueHandling = NullValueHandling.Ignore)]
        public AvatarImage[] AvatarImage { get; set; }
    }
}
