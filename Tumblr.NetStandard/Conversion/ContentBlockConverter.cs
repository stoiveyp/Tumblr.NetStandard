using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tumblr.NetStandard.Models.ContentBlocks;

namespace Tumblr.NetStandard.Conversion
{
    public class ContentBlockConverter:JsonConverter<ContentBlock>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, ContentBlock value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override ContentBlock ReadJson(JsonReader reader, Type objectType, ContentBlock existingValue, bool hasExistingValue,
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

        private ContentBlock CreateContentBlock(string discriminator)
        {
            return discriminator switch
            {
                TextBlock.BlockType => new TextBlock(),
                _ => (ContentBlock)new UnknownContentBlock(discriminator)
            };
        }
    }
}
