using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tumblr.NetStandard.OAuth.Internal;

namespace Tumblr.NetStandard.OAuth
{
    // idea is based on http://blogs.msdn.com/b/henrikn/archive/2012/02/16/extending-httpclient-with-oauth-to-access-twitter.aspx
    public class OAuthMessageHandler : DelegatingHandler
    {
        private TumblrClientCredentials Client { get; }
        Token Token;
        readonly IEnumerable<KeyValuePair<string, string>> Parameters;

        public OAuthMessageHandler(TumblrClientCredentials client, Token token = null, IEnumerable<KeyValuePair<string, string>> optionalOAuthHeaderParameters = null)
            : this(new HttpClientHandler(), client, token, optionalOAuthHeaderParameters)
        {
        }

        public OAuthMessageHandler(HttpMessageHandler innerHandler, TumblrClientCredentials client, Token token = null, IEnumerable<KeyValuePair<string, string>> optionalOAuthHeaderParameters = null)
            : base(innerHandler)
        {
            Client = client;
            this.Token = token;
            this.Parameters = optionalOAuthHeaderParameters ?? Enumerable.Empty<KeyValuePair<string, string>>();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var sendParameter = Parameters;
            if (request.Method == HttpMethod.Post)
            {
                // form url encoded content
                if (request.Content is FormUrlEncodedContent)
                {
                    // url encoded string
                    var extraParameter = await request.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var parsed = Utility.ParseQueryString(extraParameter, true); // url decoded
                    sendParameter = sendParameter.Concat(parsed);

                    request.Content = new FormUrlEncodedContentEx(parsed);
                }
                else if (request.Content is MultipartFormDataContent)
                {
                    var formPieces = new List<KeyValuePair<string, string>>();
                    foreach (var mfc in ((MultipartFormDataContent)request.Content))
                    {
                        if (!(mfc is StringContent))
                        {
                            continue;
                        }
                        formPieces.Add(new KeyValuePair<string, string>(mfc.Headers.ContentDisposition.Name, await mfc.ReadAsStringAsync()));
                    }
                    sendParameter = sendParameter.Concat(formPieces);
                }
            }

            var headerParams = OAuthUtility.BuildBasicParameters(
                Client.Id, Client.Secret,
                request.RequestUri.OriginalString, request.Method, Token,
                sendParameter);
            headerParams = headerParams.Concat(Parameters);

            var header = headerParams.Select(p => p.Key + "=" + p.Value.Wrap("\"")).ToString(",");
            request.Headers.Authorization = new AuthenticationHeaderValue("OAuth", header);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        class FormUrlEncodedContentEx : ByteArrayContent
        {
            public FormUrlEncodedContentEx(IEnumerable<KeyValuePair<string, string>> nameValueCollection)
                : base(GetContentByteArray(nameValueCollection))
            {
                base.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            }

            private static byte[] GetContentByteArray(IEnumerable<KeyValuePair<string, string>> nameValueCollection)
            {
                StringBuilder stringBuilder = new StringBuilder();
                using (IEnumerator<KeyValuePair<string, string>> enumerator = nameValueCollection.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        KeyValuePair<string, string> current = enumerator.Current;
                        if (stringBuilder.Length > 0)
                        {
                            stringBuilder.Append('&');
                        }
                        stringBuilder.Append(Encode(current.Key));
                        stringBuilder.Append('=');
                        stringBuilder.Append(Encode(current.Value));
                    }
                }
                return Encoding.UTF8.GetBytes(stringBuilder.ToString());
            }

            private static string Encode(string data)
            {
                if (string.IsNullOrEmpty(data))
                {
                    return string.Empty;
                }

                return data.UrlEncode().Replace("%20", "+");
            }
        }
    }
}