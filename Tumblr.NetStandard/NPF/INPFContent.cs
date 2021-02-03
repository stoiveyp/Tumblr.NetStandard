using System;
using System.Collections.Generic;
using System.Text;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard.NPF
{
    public interface INpfContent
    {
        ShortBlogInfo Blog { get; set; }
        ContentBlock[] Content { get; set; }
        LayoutBlock[] Layout { get; set; }
    }
}
