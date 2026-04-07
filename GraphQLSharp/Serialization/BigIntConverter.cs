using System.Text.Json;
using System.Text.Json.Serialization;

public class LongConverter : BigIntConverter<long>
{
}

public class ULongConverter : BigIntConverter<ulong>
{
}

public abstract class BigIntConverter<T> : JsonConverter<T>
{
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