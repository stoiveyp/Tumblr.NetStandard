using System.Runtime.Serialization;

namespace Tumblr.NetStandard.Api
{
    public enum UserApiPart
    {
        [EnumMember(Value="dashboard")]
        Dashboard,
        [EnumMember(Value = "likes")]
        Likes,
        [EnumMember(Value = "following")]
        Following,
        [EnumMember(Value = "follow")]
        Follow,
        [EnumMember(Value = "unfollow")]
        Unfollow,
        [EnumMember(Value = "info")]
        Info,
        [EnumMember(Value = "like")]
        Like,
        [EnumMember(Value = "unlike")]
        Unlike
    }
}