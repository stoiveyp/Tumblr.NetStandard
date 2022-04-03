using System.Net.Http;
using Tumblr.NetStandard.OAuth;

namespace Tumblr.NetStandard
{
    public class TumblrOAuth2Credentials: TumblrBaseCredentials
    {
        public string AccessToken { get; }

        public TumblrOAuth2Credentials(string accessToken)
        {
            AccessToken = accessToken;
        }

        public override DelegatingHandler Setup(TumblrClientDetail clientDetail, TumblrClientCredentials client, HttpMessageHandler handler)
        {
            if (string.IsNullOrWhiteSpace(AccessToken))
            {
                clientDetail.UseApiKey = true;
            }

            return handler == null ? new OAuth2HeaderHandler(this) : new OAuth2HeaderHandler(this, handler);
        }
    }
}