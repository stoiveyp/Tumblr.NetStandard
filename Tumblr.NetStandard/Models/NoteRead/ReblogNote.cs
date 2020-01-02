using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.NoteRead
{
    public class ReblogNote:Note
    {
        [JsonProperty("added_text")]
        public string Text { get; set; }
    }
}
