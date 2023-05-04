using System.Text.Json;
using System.Text.Json.Serialization;

namespace Train_D.Converters
{
    public class TimeConveter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                return TimeOnly.Parse(reader.GetString()).ToTimeSpan();
            }
            catch (Exception)
            {

                return new TimeSpan();
            }
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {

            writer.WriteStringValue(TimeOnly.FromTimeSpan(value).ToString());
        }
    }
}
