using System.Text.Json;
using System.Text.Json.Serialization;

public class Int64ToStringConverter : BigIntToStringConverter<long>
{
}

public class UInt64ToStringConverter : BigIntToStringConverter<ulong>
{
}

public abstract class BigIntToStringConverter<T> : JsonConverter<T>
{
    private readonly static JsonConverter<T> _defaultConverter = (JsonConverter<T>)JsonSerializerOptions.Default.GetConverter(typeof(T));
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
            return (T)Convert.ChangeType(reader.GetString(), typeof(T));

        return JsonSerializer.Deserialize<T>(ref reader);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}