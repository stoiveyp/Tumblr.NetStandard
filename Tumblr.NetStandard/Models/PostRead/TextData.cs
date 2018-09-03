using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.PostRead
{
    public class TextData
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}