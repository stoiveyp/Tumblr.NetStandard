using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tumblr.NetStandard.NPF;
using Tumblr.NetStandard.NPF.AttributionType;

namespace Tumblr.NetStandard.Conversion
{
    public class AttributionTypeConverter : JsonConverter<Attribution>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, Attribution value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override Attribution ReadJson(JsonReader reader, Type objectType, Attribution existingValue, bool hasExistingValue,
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

        private Attribution CreateContentBlock(string discriminator)
        {
            return discriminator switch
            {
                AppAttribution.AttributionType => new AppAttribution(),
                BlogAttribution.AttributionType => new BlogAttribution(),
                LinkAttribution.AttributionType => new LinkAttribution(),
                PostAttribution.AttributionType => new PostAttribution(),
                _ => (Attribution)new UnknownAttribution(discriminator)
            };
        }
    }
}