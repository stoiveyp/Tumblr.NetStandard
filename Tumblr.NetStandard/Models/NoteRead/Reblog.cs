using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.NoteRead
{
    public class Reblog
    {
        [JsonProperty("added_text")]
        public string Text { get; set; }

        [JsonIgnore]
        public string ReplyText => string.IsNullOrWhiteSpace(Text) ? "reblogged" : $"reblogged with: {Text}";
    }
}