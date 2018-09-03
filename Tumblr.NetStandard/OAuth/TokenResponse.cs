using System.Linq;
using Tumblr.NetStandard.OAuth.Internal;

namespace Tumblr.NetStandard.OAuth
{
    /// <summary>OAuth Response</summary>
    public class TokenResponse<T> where T : Token
    {
        public T Token { get; }
        public ILookup<string, string> ExtraData { get; }

        public TokenResponse(T token, ILookup<string, string> extraData)
        {
            Precondition.NotNull(token, "token");
            Precondition.NotNull(extraData, "extraData");

            this.Token = token;
            this.ExtraData = extraData;
        }
    }
}