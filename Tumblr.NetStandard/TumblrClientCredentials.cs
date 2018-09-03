using System;
using System.Collections.Generic;
using System.Text;

namespace Tumblr.NetStandard
{
    public class TumblrClientCredentials
    {
        public TumblrClientCredentials(string id, string secret)
        {
            Id = id;
            Secret = secret;
        }

        public string Id { get; set; }
        public string Secret { get; set; }
    }
}
