using System;
using System.Collections.Generic;
using System.Text;

namespace Tumblr.NetStandard
{
    public class TumblrClientCredentials
    {
        public TumblrClientCredentials(string id, string secret)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (string.IsNullOrWhiteSpace(secret))
            {
                throw new ArgumentNullException(nameof(secret));
            }

            Id = id;
            Secret = secret;
        }

        public string Id { get; set; }
        public string Secret { get; set; }
    }
}
