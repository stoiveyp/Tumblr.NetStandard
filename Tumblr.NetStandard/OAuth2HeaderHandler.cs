using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Tumblr.NetStandard
{
    public class OAuth2HeaderHandler : DelegatingHandler
    {

        public OAuth2HeaderHandler(TumblrOAuth2Credentials tumblrOAuth2Credentials, HttpMessageHandler handler) : base(handler)
        {
            CredentialsHolder = tumblrOAuth2Credentials;
        }

        public OAuth2HeaderHandler(TumblrOAuth2Credentials tumblrOAuth2Credentials):base(new HttpClientHandler())
        {
            CredentialsHolder = tumblrOAuth2Credentials;
        }

        public TumblrOAuth2Credentials CredentialsHolder { get; set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", CredentialsHolder.AccessToken);
            return base.SendAsync(request, cancellationToken);
        }
    }
}