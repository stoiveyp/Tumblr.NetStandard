using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.NoteRead
{
    public class ReplyNote : Note
    {
        [JsonProperty("reply_text")]
        public string Text { get; set; }
    }
}
