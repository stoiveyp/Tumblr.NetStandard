using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tumblr.NetStandard.Tests
{
    public class OAuth2Tests
    {
        [Fact]
        public void BuildsAuthUrlCorrect()
        {
            var uri = OAuth2.BuildAuthorizeUri("cid", OAuth2.Scopes.OfflineAccess, "state", "re-url");
            Assert.Equal("https://www.tumblr.com/oauth2/authorize?client_id=cid&response_type=code&scope=offline_access&state=state&redirect_uri=re-url",uri.ToString());
        }

        [Fact]
        public void BuildsAuthUrlWithoutRedirectCorrect()
        {
            var uri = OAuth2.BuildAuthorizeUri("cid", OAuth2.Scopes.OfflineAccess, "state");
            Assert.Equal("https://www.tumblr.com/oauth2/authorize?client_id=cid&response_type=code&scope=offline_access&state=state", uri.ToString());
        }

        [Fact]
        public async Task BuildsCodeFormCorrect()
        {
            var form = OAuth2.BuildAuthTokenForm("cid", "cis", "12345");
            var output = await form.ReadAsStringAsync();
            Assert.Equal("client_id=cid&client_secret=cis&grant_type=authorization_code&code=12345", output);
        }

        [Fact]
        public async Task BuildsRefreshFormCorrect()
        {
            var form = OAuth2.BuildRefreshTokenForm("cid", "cis", "12345");
            var output = await form.ReadAsStringAsync();
            Assert.Equal("client_id=cid&client_secret=cis&grant_type=refresh_token&refresh_token=12345", output);
        }
    }
}
