using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard
{
    public static class Extensions
    {
        public static Dictionary<string, string> AddNpf(this Dictionary<string, string> query, TumblrClientDetail detail, string key = "npf")
        {
            if (detail.UseNpf)
            {
                query.Add(key, true.ToString().ToLower());
            }
            return query;
        }

        public static string ApiPath(this BlogApiPart blogPart, string fullName, string suffix = null)
        => $"blog/{fullName}/{TranslatePart(blogPart)}{(string.IsNullOrWhiteSpace(suffix) ? string.Empty : "/")}{suffix}";

        public static string ApiPath(this UserApiPart userPart) => $"user/{TranslatePart(userPart)}";

        public static string ApiPath(this CommunityApiPart communityPart) => $"communities/{TranslatePart(communityPart)}";

        private static string TranslatePart(UserApiPart part) => ToEnumString(typeof(UserApiPart), part);
        }

        private static string TranslatePart(BlogApiPart part) => ToEnumString(typeof(BlogApiPart), part);

        private static string TranslatePart(CommunityApiPart part) => ToEnumString(typeof(CommunityApiPart), part);

        private static string ToEnumString(Type enumType, object type)
        {
            var name = Enum.GetName(enumType, type);
            var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetTypeInfo().GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).FirstOrDefault();
            return enumMemberAttribute?.Value ?? type.ToString();
        }
    }
}