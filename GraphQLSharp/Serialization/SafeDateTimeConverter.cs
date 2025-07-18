using System.Text.Json;
using System.Text.Json.Serialization;

public class SafeDateTimeConverter : SafeTDateTimeConverter<DateTime>
{
    protected override bool TryGetDateTime(ref Utf8JsonReader reader, out DateTime dateTime)
    {
        return reader.TryGetDateTime(out dateTime);
    }
}

public class SafeDateTimeOffsetConverter : SafeTDateTimeConverter<DateTimeOffset>
{
    protected override bool TryGetDateTime(ref Utf8JsonReader reader, out DateTimeOffset dateTime)
    {
        return reader.TryGetDateTimeOffset(out dateTime);
    }
}

//Some APIs return DateTime with year 0 but DateTime.MinValue is 0001-01-01
//This converter handles that case by returning default value for DateTime or DateTimeOffset
public abstract class SafeTDateTimeConverter<TDateTime> : JsonConverter<TDateTime>
{
    private readonly static JsonConverter<TDateTime> _defaultConverter = (JsonConverter<TDateTime>)JsonSerializerOptions.Default.GetConverter(typeof(TDateTime));

    protected abstract bool TryGetDateTime(ref Utf8JsonReader reader, out TDateTime dateTime);

    public override TDateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (TryGetDateTime(ref reader, out TDateTime dateTime))
            return dateTime;

        if (reader.TokenType != JsonTokenType.String)
            throw new JsonException($"Expected string JSON token for {typeof(TDateTime).Name}, got {reader.TokenType}.");

        string dateString = reader.GetString();

        // Handle special case for dates starting with "0000-", which is greater than DateTime.MinValue
        if (dateString.StartsWith("0000-"))
            return default; // Return default value for DateTime or DateTimeOffset, which is DateTime.MinValue or DateTimeOffset.MinValue

        //https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/converters-how-to#jsonexception
        //From docs: "If you throw a JsonException without a message, the serializer creates a message that includes the path to the part of the JSON that caused the error. "
        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, TDateTime value, JsonSerializerOptions options)
    {
        _defaultConverter.Write(writer, value, options);
    }
}