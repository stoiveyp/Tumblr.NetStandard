using System;
using System.Drawing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tumblr.NetStandard.NPF;
using Tumblr.NetStandard.NPF.Formatting;
using Color = Tumblr.NetStandard.NPF.Formatting.Color;

namespace Tumblr.NetStandard.Conversion
{
    public class FormattingConverter : JsonConverter<Format>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, Format value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override Format ReadJson(JsonReader reader, Type objectType, Format existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            JObject obj;
            try
            {
                obj = JObject.Load(reader);
            }
            catch (Exception)
            {
                return null;
            }

            var discriminator = obj.Value<string>("type");
            var post = CreateContentBlock(discriminator);
            serializer.Populate(obj.CreateReader(), post);
            return post;
        }

        private Format CreateContentBlock(string discriminator)
        {
            return discriminator switch
            {
                Bold.FormattingType => new Bold(),
                Italic.FormattingType => new Italic(),
                Strikethrough.FormattingType => new Strikethrough(),
                Link.FormattingType => new Link(),
                Mention.FormattingType => new Mention(),
                Color.FormattingType => new Color(),
                _ => (Format)new UnknownFormat(discriminator)
            };
        }
    }
}
