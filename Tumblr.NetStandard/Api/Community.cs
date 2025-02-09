using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Tumblr.NetStandard.Conversion;

namespace Tumblr.NetStandard.Api
{
    public class Community:ShortCommunity
    {
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("about", NullValueHandling = NullValueHandling.Ignore)]
        public string About { get; set; }

        [JsonProperty("guidelines", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Guidelines { get; set; }

        [JsonProperty("visibility", NullValueHandling = NullValueHandling.Ignore)]
        public string Visibility { get; set; }

        [JsonProperty("members_online_count", NullValueHandling = NullValueHandling.Ignore)]
        public string MembersOnlineCount { get; set; }

        [JsonProperty("is_member", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsMember { get; set; }

        [JsonProperty("can_post", NullValueHandling = NullValueHandling.Ignore)]
        public bool CanPost { get; set; }

        [JsonProperty("can_edit", NullValueHandling = NullValueHandling.Ignore)]
        public bool CanEdit { get; set; }

        [JsonProperty("can_interact", NullValueHandling = NullValueHandling.Ignore)]
        public bool CanInteract { get; set; }

        [JsonProperty("can_invite", NullValueHandling = NullValueHandling.Ignore)]
        public bool CanInvite { get; set; }

        [JsonProperty("can_view_comments", NullValueHandling = NullValueHandling.Ignore)]
        public bool CanViewComments { get; set; }

        [JsonProperty("post_count", NullValueHandling = NullValueHandling.Ignore)]
        public int PostCount { get; set; }

        [JsonProperty("unread_post_count", NullValueHandling = NullValueHandling.Ignore)]
        public int UnreadPostCount { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Tags { get; set; }

        [JsonProperty("created_ts"), JsonConverter(typeof(EpochDateTimeHandler))]
        public DateTime CreatedTimestamp { get; set; }

        [JsonProperty("handle_can_change", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HandleCanChange { get; set; }

        [JsonProperty("handle_next_change_ts", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HandleNextChangeTs { get; set; }

        [JsonProperty("invitation", NullValueHandling = NullValueHandling.Ignore)]
        public Invitation Invitation { get; set; }

        [JsonProperty("can_edit_content_label", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CanEditContentLabel { get; set; }

        [JsonProperty("settings", NullValueHandling = NullValueHandling.Ignore)]
        public CommunitySettings Settings { get; set; }

        [JsonProperty("header_image", NullValueHandling = NullValueHandling.Ignore)]
        public HeaderImage[] HeaderImage { get; set; }

        [JsonProperty("population_cap", NullValueHandling = NullValueHandling.Ignore)]
        public int PopulationCap { get; set; }

        [JsonProperty("join_type", NullValueHandling = NullValueHandling.Ignore)]
        public string JoinType { get; set; }

        [JsonProperty("has_content_label", NullValueHandling = NullValueHandling.Ignore)]
        public bool HasContentLabel { get; set; }

        [JsonProperty("content_label_categories", NullValueHandling = NullValueHandling.Ignore)]
        public string[] ContentLabelCategories { get; set; }

        [JsonProperty("invite_link", NullValueHandling = NullValueHandling.Ignore)]
        public string InviteLink { get; set; }

        [JsonProperty("pending_invitations_count", NullValueHandling = NullValueHandling.Ignore)]
        public bool PendingInvitationsCount { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; }

    }
}
