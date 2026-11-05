using System.Text.Json;
using System.Text.Json.Serialization;

namespace GraphQLSharp;

internal sealed class GraphQLHttpErrorMessageConverter : JsonConverter<string>
{
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
            return reader.GetString();

        using var document = JsonDocument.ParseValue(ref reader);
        var errors = document.RootElement;
        if (errors.ValueKind != JsonValueKind.Array)
            return null;

        return string.Join("\n", errors.EnumerateArray()
            .Where(error => error.ValueKind == JsonValueKind.Object
                && error.TryGetProperty("message", out var message)
                && message.ValueKind == JsonValueKind.String)
            .Select(error => error.GetProperty("message").GetString()));
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}
