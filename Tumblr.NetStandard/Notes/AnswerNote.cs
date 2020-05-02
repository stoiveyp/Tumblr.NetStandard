using Newtonsoft.Json;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard.Notes
{
    public class AnswerNote:Note
    {
        [JsonProperty("answer_text")]
        public string Text { get; set; }
    }
}
