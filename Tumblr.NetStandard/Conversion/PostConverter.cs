using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tumblr.NetStandard.Api;
using Tumblr.NetStandard.Posts;

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

        private Post CreatePost(string type)
        {
            return type switch
            {
                TextPost.PostType => new TextPost(),
                PhotoPost.PostType => new PhotoPost(),
                QuotePost.PostType => new QuotePost(),
                LinkPost.PostType => new LinkPost(),
                ChatPost.PostType => new ChatPost(),
                AudioPost.PostType => new AudioPost(),
                VideoPost.PostType => new VideoPost(),
                AnswerPost.PostType => new AnswerPost(),
                BlocksPost.PostType => new BlocksPost(),
                _ => new UnknownPost(type)

            };
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Post) || objectType.IsSubclassOf(typeof(Post));
        }
    }
}
