using System;
using Newtonsoft.Json;

namespace Tumblr.NetStandard
{
    public class TumblrCredentials
    {
        public TumblrCredentials(string key, string secret)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (string.IsNullOrWhiteSpace(secret))
            {
                throw new ArgumentNullException(nameof(secret));
            }

            Key = key;
            Secret = secret;
        }

        [JsonProperty("login")]
        public string Key { get; set; }

        [JsonProperty("secret")]
        public string Secret { get; set; }
    }
}
