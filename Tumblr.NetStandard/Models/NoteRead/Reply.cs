using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.NoteRead
{
    public struct Reply
    {
        [JsonProperty("reply_text")]
        public string Text { get; set; }
    }
}