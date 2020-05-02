using Tumblr.NetStandard.Api;
using Tumblr.NetStandard.NPF.ContentBlocks;

namespace Tumblr.NetStandard.Posts
{
    public class BlocksPost:Post
    {
        public ContentBlock[] Content { get; set; }
    }
}
