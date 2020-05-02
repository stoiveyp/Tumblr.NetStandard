using System.Collections.Generic;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard
{
    public static class Extensions
    {
        public static Dictionary<string, string> AddNpf(this Dictionary<string, string> query, TumblrClientDetail detail)
        {
            if (detail.UseNpf)
            {
                query.Add("npf", true.ToString().ToLower());
            }
            return query;
        }

        public static string ApiPath(this BlogApiPart blogPart, string fullName)
        {
            return $"blog/{fullName}/{TranslatePart(blogPart)}";
        }

        public static string ApiPath(this UserApiPart blogPart)
        {
            return $"user/{TranslatePart(blogPart)}";
        }

        private static string TranslatePart(UserApiPart part)
        {
            return part switch
            {
                UserApiPart.Dashboard => "dashboard",
                UserApiPart.Likes => "likes",
                UserApiPart.Following => "following",
                UserApiPart.Follow => "follow",
                UserApiPart.Unfollow => "unfollow",
                UserApiPart.Like => "like",
                UserApiPart.Unlike => "unlike",
                _ => "info"
            };
        }

        private static string TranslatePart(BlogApiPart part)
        {
            return part switch
            {
                BlogApiPart.Posts => "posts",
                BlogApiPart.Avatar => "avatar",
                _ => "info"
            };
        }
    }
}