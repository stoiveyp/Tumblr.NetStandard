using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.PostRead
{
    public class ChatData
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("dialogue")]
        public List<DialogueLine> Dialogue { get; set; }
    }
}