using System;
using System.Linq;

namespace Tumblr.NetStandard.Api
{
    public enum AvatarSize
    {
        Small = 48,
        Profile = 96,
        LargeProfile = 128,
        Large = 512
    }

    public static class AvatarExtensions
    {

        public static Uri GetAvatar(this Uri blogUri, int width)
        {
            return GetAvatar(blogUri.Host, width);
        }

        public static Uri GetAvatar(this IAvatar avatarAvailable, AvatarSize width)
        {
            return GetAvatar(avatarAvailable.BlogName, (int)width);
        }

        public static Uri GetAvatar(this IAvatar avatarAvailable, int width)
        {
            return GetAvatar(avatarAvailable.BlogName, width);
        }

        public static Uri GetAvatar(this string blogUri, int width)
        {
            return new Uri($"https://api.tumblr.com/v2/blog/{blogUri}/avatar/{GetSize(width)}", UriKind.Absolute);
        }

        private static readonly int[] Sizes = { 16, 30, 40, 48, 64, 96, 128, 512 };

        private static int GetSize(int width)
        {
            if (width <= Sizes[0])
            {
                return Sizes[0];
            }

            return Sizes.Skip(1).FirstOrDefault(i => width <= i);
        }
    }
}
