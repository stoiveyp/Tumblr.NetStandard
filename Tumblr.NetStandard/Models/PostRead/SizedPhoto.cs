using System;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.PostRead
{
    public class SizedPhoto
    {
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("url")]
        public Uri Location{ get; set; }

        public static implicit operator SizedPhoto(string data)
        {
            var pieces = data.Split(new[] { "~~||~~" }, 3, StringSplitOptions.None);
            return new SizedPhoto {Location = new Uri(pieces[0],UriKind.Absolute),Width=int.Parse(pieces[1]),Height=int.Parse(pieces[2])};
        }

        public static implicit operator string(SizedPhoto data)
        {
            return data.Location + "~~||~~" + data.Width + "~~||~~" + data.Height;
        }
    }
}