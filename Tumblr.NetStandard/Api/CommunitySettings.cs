using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tumblr.NetStandard.Api
{
    public class CommunitySettings
    {
        [JsonProperty("invite_links_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool InviteLinksEnabled { get; set; }

        [JsonProperty("join_type", NullValueHandling = NullValueHandling.Ignore)]
        public string JoinType { get; set; }

        [JsonProperty("mods_can_invite", NullValueHandling = NullValueHandling.Ignore)]
        public bool ModsCanInvite { get; set; }

        [JsonProperty("automod_links", NullValueHandling = NullValueHandling.Ignore)]
        public bool AutomodLinks { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; }
    }
}