using System.Runtime.Serialization;

namespace Tumblr.NetStandard.Api
{
    public enum BlogApiPart
    {
        [EnumMember(Value = "posts")]
        Posts,
        [EnumMember(Value = "avatar")]
        Avatar,
        [EnumMember(Value = "delete")]
        Delete,
        [EnumMember(Value = "following")]
        Following,
        [EnumMember(Value = "followers")]
        Followers,
        [EnumMember(Value = "info")]
        Info,
        [EnumMember(Value = "posts/submission")]
        Submission,
        [EnumMember(Value = "posts/queue")]
        Queue,
        [EnumMember(Value = "posts/draft")]
        Draft
    }
}