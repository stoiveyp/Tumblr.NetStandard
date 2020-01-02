using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.PostRead
{
    public class ChatPost:Post
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("dialogue")]
        public DialogueLine[] Dialogue { get; set; }
    }
}
