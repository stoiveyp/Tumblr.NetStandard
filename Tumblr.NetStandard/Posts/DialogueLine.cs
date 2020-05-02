using Newtonsoft.Json;

namespace Tumblr.NetStandard.Posts
{
    public class DialogueLine
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phrase")]
        public string Phrase { get; set; }
    }
}