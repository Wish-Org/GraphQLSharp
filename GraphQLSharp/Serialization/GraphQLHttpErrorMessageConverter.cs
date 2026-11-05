using System.Text.Json;
using System.Text.Json.Serialization;

namespace GraphQLSharp;

internal sealed class GraphQLHttpErrorMessageConverter : JsonConverter<List<string>>
{
    public override List<string> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
            return [reader.GetString()];

        using var document = JsonDocument.ParseValue(ref reader);
        var errors = document.RootElement;
        if (errors.ValueKind != JsonValueKind.Array)
            return null;

        var messages = new List<string>();
        foreach (var error in errors.EnumerateArray())
        {
            if (error.ValueKind == JsonValueKind.String)
                messages.Add(error.GetString());
            else if (error.ValueKind == JsonValueKind.Object
                && error.TryGetProperty("message", out var message)
                && message.ValueKind == JsonValueKind.String)
                messages.Add(message.GetString());
        }
        return messages;
    }

    public override void Write(Utf8JsonWriter writer, List<string> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (var message in value)
            writer.WriteStringValue(message);
        writer.WriteEndArray();
    }
}
