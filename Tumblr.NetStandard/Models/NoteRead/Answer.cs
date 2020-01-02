using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.NoteRead
{
    public class Answer
    {
        [JsonProperty("answer_text")]
        public string Text { get; set; }
    }
}