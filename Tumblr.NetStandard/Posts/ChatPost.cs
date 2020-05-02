using Newtonsoft.Json;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard.Posts
{
    public class ChatPost:Post
    {
        public const string PostType = "chat";
        [JsonProperty("type")] public override string Type => PostType;

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("dialogue")]
        public DialogueLine[] Dialogue { get; set; }
    }
}
