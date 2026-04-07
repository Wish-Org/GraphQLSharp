using System.Globalization;
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
            return (T)Convert.ChangeType(reader.GetString(), typeof(T), CultureInfo.InvariantCulture);

        return _defaultConverter.Read(ref reader, typeToConvert, options);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(((IFormattable)value).ToString(null, CultureInfo.InvariantCulture));
    }
}