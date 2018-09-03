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
        string consumerKey;
        string consumerSecret;
        Token token;
        IEnumerable<KeyValuePair<string, string>> parameters;

        public OAuthMessageHandler(string consumerKey, string consumerSecret, Token token = null, IEnumerable<KeyValuePair<string, string>> optionalOAuthHeaderParameters = null)
            : this(new HttpClientHandler(), consumerKey, consumerSecret, token, optionalOAuthHeaderParameters)
        {
        }

        public OAuthMessageHandler(HttpMessageHandler innerHandler, string consumerKey, string consumerSecret, Token token = null, IEnumerable<KeyValuePair<string, string>> optionalOAuthHeaderParameters = null)
            : base(innerHandler)
        {
            this.consumerKey = consumerKey;
            this.consumerSecret = consumerSecret;
            this.token = token;
            this.parameters = optionalOAuthHeaderParameters ?? Enumerable.Empty<KeyValuePair<string, string>>();
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var sendParameter = parameters;
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
                        if(!(mfc is StringContent))
                        {
                            continue;
                        }
                        formPieces.Add(new KeyValuePair<string, string>(mfc.Headers.ContentDisposition.Name,await mfc.ReadAsStringAsync()));
                    }
                    sendParameter = sendParameter.Concat(formPieces);
                }
            }

            var headerParams = OAuthUtility.BuildBasicParameters(
                consumerKey, consumerSecret,
                request.RequestUri.OriginalString, request.Method, token,
                sendParameter);
            headerParams = headerParams.Concat(parameters);

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