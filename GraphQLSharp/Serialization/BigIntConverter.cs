using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

public class LongConverter : JsonConverter<long>
{
    public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var str = reader.GetString();
            if (long.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
                return result;
            throw new JsonException($"Unable to parse '{str}' as a long.");
        }

        if (reader.TokenType == JsonTokenType.Number)
            return reader.GetInt64();

        throw new JsonException($"Unexpected token type {reader.TokenType} when parsing long.");
    }

    public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
    }
}

public class ULongConverter : JsonConverter<ulong>
{
    public override ulong Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var str = reader.GetString();
            if (ulong.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
                return result;
            throw new JsonException($"Unable to parse '{str}' as a ulong.");
        }

        if (reader.TokenType == JsonTokenType.Number)
            return reader.GetUInt64();

        throw new JsonException($"Unexpected token type {reader.TokenType} when parsing ulong.");
    }

    public override void Write(Utf8JsonWriter writer, ulong value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
    }
}

[Obsolete("Use LongConverter or ULongConverter directly.")]
public abstract class BigIntConverter<T> : JsonConverter<T>
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var str = reader.GetString();
            try
            {
                return (T)Convert.ChangeType(str, typeof(T), CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                throw new JsonException($"Unable to parse '{str}' as {typeof(T).Name}.", ex);
            }
        }

        throw new JsonException($"Unexpected token type {reader.TokenType} when parsing {typeof(T).Name}.");
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(Convert.ToString(value, CultureInfo.InvariantCulture));
    }
}