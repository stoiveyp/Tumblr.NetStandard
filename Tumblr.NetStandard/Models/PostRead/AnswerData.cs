using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.PostRead
{
    public class AnswerData
    {
        [JsonProperty("asking_name")]
        public string AskingName { get; set; }

        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("answer")]
        public string Answer { get; set; }
    }
}