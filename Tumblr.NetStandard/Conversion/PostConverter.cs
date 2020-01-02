using System;
using Tumblr.NetStandard.Models;
using Tumblr.NetStandard.Models.PostRead;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tumblr.NetStandard.Conversion
{
    public class PostConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
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
            var post = CreatePost(discriminator);
            serializer.Populate(obj.CreateReader(), post);
            return post;
        }

        private Post CreatePost(string discriminator)
        {
            return discriminator switch
            {
                "text" => new TextPost(),
                "photo" => new PhotoPost(),
                "quote" => new QuotePost(),
                "link" => new LinkPost(),
                "chat" => new ChatPost(),
                "audio" => new AudioPost(),
                "video" => new VideoPost(),
                "answer" => new AnswerPost(),
                _ => new Post()

            };
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Post) || objectType.IsSubclassOf(typeof(Post));
        }
    }
}
