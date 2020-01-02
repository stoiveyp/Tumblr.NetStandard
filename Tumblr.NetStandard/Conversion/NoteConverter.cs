using System;
using Tumblr.NetStandard.Models;
using Tumblr.NetStandard.Models.NoteRead;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tumblr.NetStandard.Conversion
{
    public class NoteConverter : JsonConverter
    {
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);
            var discriminator = obj.Value<string>("type");

            var note = GenerateNote(discriminator);
            serializer.Populate(obj.CreateReader(), note);

            return note;
        }

        private Note GenerateNote(string discriminator)
        {
            return discriminator switch
            {
                "like" => new LikeNote(),
                "answer" => new AnswerNote(),
                "note_model" => new ReplyNote(),
                "comment" => new ReplyNote(),
                "reply" => new ReplyNote(),
                "reblog" => new ReblogNote(),
                _ => new Note()
            };
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Note) || objectType.IsSubclassOf(typeof(Note));
        }
    }
}
