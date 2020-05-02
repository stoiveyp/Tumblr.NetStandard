using Newtonsoft.Json;
using Tumblr.NetStandard.Conversion;

namespace Tumblr.NetStandard.NPF.ContentBlocks
{
    [JsonConverter(typeof(ContentBlockConverter))]
    public abstract class ContentBlock
    {
        public abstract string Type { get; }
    }
}
