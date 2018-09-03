using System;

namespace Tumblr.NetStandard.Conversion
{
    public static class DateTimeExtensions
    {
        static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long UtcToEpoch(this DateTime target)
        {
            return (long)(target - UnixEpoch).TotalSeconds;
        }

        public static DateTime UtcFromEpoch(this long epochTime)
        {
            return UnixEpoch.AddSeconds(epochTime);
        }
    }
}
