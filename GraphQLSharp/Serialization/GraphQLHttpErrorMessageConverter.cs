using System.Text.Json;
using System.Text.Json.Serialization;

namespace GraphQLSharp;

// Normalizes the value of an HTTP error response's "errors" property into individual messages:
//   "Service unavailable"                         -> one message
//   ["First error", "Second error"]               -> multiple messages
//   [{"message":"First"}, {"message":"Second"}]   -> GraphQL error object messages
// Arrays may mix strings and error objects; message order is preserved.
// JSON null is handled by System.Text.Json and remains null.
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
        // Non-null lists are always written as JSON string arrays, regardless of the input format.
        writer.WriteStartArray();
        foreach (var message in value)
            writer.WriteStringValue(message);
        writer.WriteEndArray();
    }
}
