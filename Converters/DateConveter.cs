using System.Text.Json;
using System.Text.Json.Serialization;

namespace Train_D.Converters
{
    public class DateConveter : JsonConverter<DateTime>
    {
        private string formatDate = "dd/MM/yyyy";
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                return DateTime.Parse(reader.GetString());
            }
            catch (Exception)
            {

                return new DateTime();
            }
        }
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(formatDate));
        }
    }
}
