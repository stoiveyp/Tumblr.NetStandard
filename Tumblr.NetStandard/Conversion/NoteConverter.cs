using System;
using Tumblr.NetStandard.Models;
using Tumblr.NetStandard.Models.NoteRead;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tumblr.NetStandard.Conversion
{
    public class NoteConverter : JsonConverter
    {
        private static NoteConverter _instance;
        public static NoteConverter Instance => _instance ??= new NoteConverter();

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            string discriminator = (string)obj["type"];

            Note note = GenerateNote(discriminator);

            switch (note)
            {
                case AnswerNote a:
                    serializer.Populate(obj.CreateReader(), a.Extra);
                    break;
                case ReplyNote re:
                    serializer.Populate(obj.CreateReader(), re.Extra);
                    break;
                case ReblogNote rb:
                    serializer.Populate(obj.CreateReader(), rb.Extra);
                    break;
            }

            serializer.Populate(obj.CreateReader(), note.Common);

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
