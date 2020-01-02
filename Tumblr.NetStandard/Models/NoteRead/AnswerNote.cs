using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.NoteRead
{
    public class AnswerNote:Note
    {
        [JsonProperty("answer_text")]
        public string Text { get; set; }
    }
}
