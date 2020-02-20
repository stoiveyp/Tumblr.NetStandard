using System;
using System.Collections.Generic;
using System.Text;

namespace Tumblr.NetStandard.Models.PostRead
{
    public class BlocksPost:Post
    {
        private ContentBlock[] Content { get; set; }
    }
}
