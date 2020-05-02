using System;
using Xunit;

namespace Tumblr.NetStandard.Tests
{
    public class ConstructorTests
    {
        [Fact]
        public void TestClientCredsNullThrows()
        {
            Assert.Throws<ArgumentNullException>(() => new TumblrClient(null));
        }

        [Fact]
        public void ValidClientCredsPasses()
        {
            var _ = new TumblrClient(new TumblrClientCredentials("xxx", "yyy"));
        }

        [Fact]
        public void ValidClientWithLogin()
        {
            var _ = new TumblrClient(new TumblrClientCredentials("xxx", "yyy"),
                new TumblrCredentials("testkey", "testsecret"));
        }

        [Fact]
        public void TumblrCredentialsFieldsMustNotBeNull()
        {
            Assert.Throws<ArgumentNullException>(() => new TumblrCredentials(null, "secret"));
            Assert.Throws<ArgumentNullException>(() => new TumblrCredentials("id", null));
        }

        [Fact]
        public void TumblrClientCredentialsFieldsMustNotBeNull()
        {
            Assert.Throws<ArgumentNullException>(() => new TumblrClientCredentials(null, "secret"));
            Assert.Throws<ArgumentNullException>(() => new TumblrClientCredentials("id", null));
        }
    }
}
