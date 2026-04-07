using System.Text.Json.Serialization;
using System.Text.Json;
using System.Collections.Concurrent;

namespace GraphQLSharp;

#nullable enable

public static class Serializer
{
    private static readonly ConcurrentDictionary<(bool indent, bool serializeInt64ToString), JsonSerializerOptions> _optionsToJsonOptions = new();

    static Serializer()
    {
    }

    public static JsonSerializerOptions CreateOptions(bool indent, bool serializeInt64ToString)
    {
        var options = new JsonSerializerOptions
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            Converters = {
                new JsonStringEnumConverter(),
                new SafeDateTimeConverter(),
                new SafeDateTimeOffsetConverter()
            },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };

        if (serializeInt64ToString)
        {
            options.Converters.Add(new Int64ToStringConverter());
            options.Converters.Add(new UInt64ToStringConverter());
        }

        if (indent)
            options.WriteIndented = true;

        return options;
    }

    public static JsonSerializerOptions GetOptions(bool indent = false, bool serializeInt64ToString = true)
    {
        return _optionsToJsonOptions.GetOrAdd((indent, serializeInt64ToString), _ => CreateOptions(indent, serializeInt64ToString));
    }

    public static string Serialize(object obj, bool indent = false, bool serializeInt64ToString = true)
    {
        return JsonSerializer.Serialize(obj, obj.GetType(), GetOptions(indent, serializeInt64ToString));
    }

    public static object? Deserialize(string json, Type type, bool indent = false, bool serializeInt64ToString = true)
    {
        return JsonSerializer.Deserialize(json, type, GetOptions(indent, serializeInt64ToString));
    }

    public static T? Deserialize<T>(string json, bool indent = false, bool serializeInt64ToString = true)
    {
        return JsonSerializer.Deserialize<T>(json, GetOptions(indent, serializeInt64ToString));
    }
}