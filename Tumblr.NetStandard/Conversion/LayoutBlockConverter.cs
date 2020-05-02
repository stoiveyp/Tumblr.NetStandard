using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tumblr.NetStandard.NPF;
using Tumblr.NetStandard.NPF.LayoutBlocks;

namespace Tumblr.NetStandard.Conversion
{
    public class LayoutBlockConverter : JsonConverter<LayoutBlock>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, LayoutBlock value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override LayoutBlock ReadJson(JsonReader reader, Type objectType, LayoutBlock existingValue, bool hasExistingValue,
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

        private LayoutBlock CreateContentBlock(string discriminator)
        {
            return discriminator switch
            {
                RowsLayout.LayoutType => new RowsLayout(),
                CondensedLayout.LayoutType=> new CondensedLayout(),
                AskLayout.LayoutType => new AskLayout(),
                _ => (LayoutBlock)new UnknownLayoutBlock(discriminator)
            };
        }
    }
}