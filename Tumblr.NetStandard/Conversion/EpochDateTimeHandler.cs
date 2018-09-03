using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Tumblr.NetStandard.Conversion
{
    public class EpochDateTimeHandler : DateTimeConverterBase
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).UtcToEpoch());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.ValueType == typeof(String))
            {
                return DateTime.Parse(reader.Value.ToString()).ToUniversalTime();
            }
            return ((long)reader.Value).UtcFromEpoch();
        }
    }
}