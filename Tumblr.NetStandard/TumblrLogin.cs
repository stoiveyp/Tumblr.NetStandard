using System;
using System.Threading.Tasks;
using Tumblr.NetStandard.OAuth;

namespace Tumblr.NetStandard
{
    public abstract class TumblrLogin : ITumblrLogin
    {
        private const string RequestUrl = "https://www.tumblr.com/oauth/request_token";
        private const string AuthorizeUrl = "https://www.tumblr.com/oauth/authorize";
        private const string AccessTokenUrl = "https://www.tumblr.com/oauth/access_token";
        private readonly Func<Uri, Uri, Task<string>> ContactWebAuthenticationBroker;
        private readonly Uri CallbackUri;
        private TumblrClientCredentials Consumer;

        protected TumblrLogin(TumblrClientCredentials consumer, Uri callbackUri, Func<Uri, Uri, Task<string>> webBrokerCall)
        {
            Consumer = consumer;
            ContactWebAuthenticationBroker = webBrokerCall;
            CallbackUri = callbackUri;
        }

        public async Task<TumblrCredentials> Login()
        {
            var authorizer = new OAuthAuthorizer(Consumer.Id, Consumer.Secret);

            // get request token
            var tokenResponse = await authorizer.GetRequestToken(RequestUrl);
            var requestToken = tokenResponse.Token;

            var startUri = new Uri(authorizer.BuildAuthorizeUrl(AuthorizeUrl, requestToken));
            var tokenString = await ContactWebAuthenticationBroker(startUri, CallbackUri);
            if (string.IsNullOrWhiteSpace(tokenString))
            {
                return null;
            }
            return await GetAccessToken(Consumer.Id,Consumer.Secret,tokenString, requestToken.Secret);
        }

        protected async Task<TumblrCredentials> GetAccessToken(string consumerKey, string consumerSecret, string webAuthResultResponseData, string tokenSecret)
        {
            string responseData = webAuthResultResponseData.Substring(webAuthResultResponseData.IndexOf("oauth_token", StringComparison.Ordinal));
            if (responseData.EndsWith("#_=_"))
            {
                responseData = responseData.Substring(0, responseData.Length - 4);
            }
            string requestToken = null, oauthVerifier = null;
            String[] keyValPairs = responseData.Split('&');

            foreach (string t in keyValPairs)
            {
                String[] splits = t.Split('=');
                switch (splits[0])
                {
                    case "oauth_token":
                        requestToken = splits[1];
                        break;
                    case "oauth_verifier":
                        oauthVerifier = splits[1];
                        break;
                }
            }

            var authorizer = new OAuthAuthorizer(consumerKey, consumerSecret);

            var accessToken = await authorizer.GetAccessToken(AccessTokenUrl,new RequestToken(requestToken, tokenSecret), oauthVerifier).ConfigureAwait(false);
            return new TumblrCredentials(accessToken.Token.Key, accessToken.Token.Secret);
        }
    }
}
