using System;
using Tumblr.NetStandard.Models;
using Tumblr.NetStandard.Models.PostRead;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tumblr.NetStandard.Conversion
{
    public class PostConverter : JsonConverter
    {
        private static PostConverter _instance;
        public static PostConverter Instance => _instance ?? (_instance = new PostConverter());

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

            string discriminator = (string)obj["type"];

            Post post = CreatePost(discriminator);

            switch (post)
            {
                case TextPost t:
                    serializer.Populate(obj.CreateReader(), t.Data);
                    break;
                case PhotoPost p:
                    serializer.Populate(obj.CreateReader(), p.Data);
                    break;
                case QuotePost q:
                    serializer.Populate(obj.CreateReader(), q.Data);
                    break;
                case LinkPost l:
                    serializer.Populate(obj.CreateReader(), l.Data);
                    break;
                case ChatPost c:
                    serializer.Populate(obj.CreateReader(), c.Data);
                    break;
                case AudioPost au:
                    serializer.Populate(obj.CreateReader(), au.Data);
                    break;
                case VideoPost v:
                    serializer.Populate(obj.CreateReader(), v.Data);
                    break;
                case AnswerPost a:
                    serializer.Populate(obj.CreateReader(), a.Data);
                    break;
            }

            serializer.Populate(obj.CreateReader(), post.Common);  // Won't work, as reader has been moved
            serializer.Populate(obj.CreateReader(), post.Reblog);
            if (post.Common.NoteCount > 0)
            {
                serializer.Populate(obj.Value<JArray>("notes").CreateReader(), post.Notes);
            }
            return post;
        }

        private Post CreatePost(string discriminator)
        {
            Post post;
            switch (discriminator)
            {
                case "text":
                    post = new TextPost();
                    break;
                case "photo":
                    post = new PhotoPost();
                    break;
                case "quote":
                    post = new QuotePost();
                    break;
                case "link":
                    post = new LinkPost();
                    break;
                case "chat":
                    post = new ChatPost();
                    break;
                case "audio":
                    post = new AudioPost();
                    break;
                case "video":
                    post = new VideoPost();
                    break;
                case "answer":
                    post = new AnswerPost();
                    break;
                default:
                    post = default(Post);
                    break;
            }
            return post;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var so = JsonConvert.SerializeObject(value, NoteConverter.Instance);
            writer.WriteRaw(so);
            writer.WriteRaw(",");
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.FullName.EndsWith("Post");
        }
    }
}
