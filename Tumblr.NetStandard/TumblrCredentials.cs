using Newtonsoft.Json;

namespace Tumblr.NetStandard
{
    public class TumblrCredentials
    {
        public TumblrCredentials(string key, string secret)
        {
            Key = key;
            Secret = secret;
        }

        [JsonProperty("login")]
        public string Key { get; set; }

        [JsonProperty("secret")]
        public string Secret { get; set; }
    }
}
