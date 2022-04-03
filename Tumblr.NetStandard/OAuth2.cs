using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Tumblr.NetStandard
{
    public static class OAuth2
    {
        public const string AuthorizeUrl = "https://www.tumblr.com/oauth2/authorize";
        public const string TokenUrl = "https://api.tumblr.com/v2/oauth2/token";

        public static Uri BuildAuthorizeUri(string clientId, string scopes, string state, string redirectUrl = null)
        {
            var builder = new UriBuilder(AuthorizeUrl)
            {
                Query = $"?client_id={clientId}&response_type=code&scope={scopes}&state={WebUtility.UrlEncode(state)}"
            };

            if (!string.IsNullOrWhiteSpace(redirectUrl))
            {
                builder.Query = builder.Query + "&redirect_uri=" + WebUtility.UrlEncode(redirectUrl);
            }

            return builder.Uri;
        }

        public static FormUrlEncodedContent BuildAuthTokenForm(string clientId, string clientSecret, string code)
        {
            return new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"client_id", clientId },
                {"client_secret", clientSecret },
                {"grant_type", "authorization_code" },
                {"code", code }

            });
        }

        public static FormUrlEncodedContent BuildRefreshTokenForm(string clientId, string clientSecret, string refreshToken)
        {
            return new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"client_id", clientId },
                {"client_secret", clientSecret },
                {"grant_type", "refresh_token" },
                {"refresh_token", refreshToken }

            });
        }

        public static Dictionary<string, string> ParseQuerystring(string query) =>
            OAuth.Internal.Utility.ParseQueryString(query).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        public static class Scopes
        {
            public const string Basic = "basic";
            public const string Write = "write";
            public const string OfflineAccess = "offline_access";

        }
    }
}
