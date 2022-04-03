using System;
using System.Net.Http;
using Newtonsoft.Json;
using Tumblr.NetStandard.OAuth;

namespace Tumblr.NetStandard
{
    public abstract class TumblrBaseCredentials
    {
        public abstract DelegatingHandler Setup(TumblrClientDetail clientDetail, TumblrClientCredentials client,
            HttpMessageHandler handler);
    }

    public class TumblrCredentials:TumblrBaseCredentials
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

        public override DelegatingHandler Setup(TumblrClientDetail clientDetail, TumblrClientCredentials client, HttpMessageHandler handler)
        {
            if (string.IsNullOrWhiteSpace(Key) || string.IsNullOrWhiteSpace(Secret))
            {
                clientDetail.UseApiKey = true;
            }
            else
            {
                clientDetail.AccessToken = new AccessToken(Key, Secret);
            }

            return handler == null
                ? new OAuthMessageHandler(client, clientDetail.AccessToken)
                : new OAuthMessageHandler(handler, client, clientDetail.AccessToken);
        }
    }
}
