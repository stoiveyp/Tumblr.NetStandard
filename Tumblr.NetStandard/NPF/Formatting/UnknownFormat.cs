using Newtonsoft.Json;

namespace Tumblr.NetStandard.NPF.Formatting
{
    public class UnknownFormat : Format
    {
        public UnknownFormat(string type)
        {
            Type = type;
        }

        [JsonProperty("type")]
        public override string Type { get; }
    }
}