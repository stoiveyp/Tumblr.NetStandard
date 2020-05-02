using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tumblr.NetStandard.Tests
{
    public static class Utility
    {
        private static readonly JsonSerializer Serializer = JsonSerializer.CreateDefault(
            new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new UriAsStringConverter()}
            });

        private const string ExamplesPath = "Examples";
        public static bool CompareJson(object actual, string expectedFile, Func<JObject,JToken> getToken = null)
        {
            var expected = ExampleFileContent(expectedFile);
            var actualJObject = JObject.FromObject(actual,Serializer);
            var expectedJObject = JObject.Parse(expected);
            if (getToken != null)
            {
                return JToken.DeepEquals(getToken(actualJObject), getToken(expectedJObject));
            }
            return JToken.DeepEquals(expectedJObject, actualJObject);
        }
        public static T ExampleFileContent<T>(string expectedFile)
        {
            using (var reader = new JsonTextReader(new StringReader(ExampleFileContent(expectedFile))))
            {
                return new JsonSerializer().Deserialize<T>(reader);
            }
        }
        public static string ExampleFileContent(string expectedFile)
        {
            return File.ReadAllText(Path.Combine(ExamplesPath, expectedFile));
        }
    }

    internal class UriAsStringConverter : JsonConverter
    {
        public override bool CanRead => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((Uri)value).OriginalString);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Uri);
        }
    }
}
