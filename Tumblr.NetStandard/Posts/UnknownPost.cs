using System.Collections.Generic;
using Newtonsoft.Json;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard.Posts
{
    public class UnknownPost : Post
    {
        public UnknownPost(string type)
        {
            Type = type;
        }

        [JsonProperty("type")] public override string Type { get; }
    }
}