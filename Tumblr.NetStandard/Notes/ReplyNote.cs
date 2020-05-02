using Newtonsoft.Json;
using Tumblr.NetStandard.Api;
using Tumblr.NetStandard.NPF.Formatting;

namespace Tumblr.NetStandard.Notes
{
    public class ReplyNote : Note
    {
        [JsonProperty("reply_text")]
        public string Text { get; set; }

        [JsonProperty("formatting",NullValueHandling = NullValueHandling.Ignore)]
        public Format[] Formatting { get; set; }
    }
}
