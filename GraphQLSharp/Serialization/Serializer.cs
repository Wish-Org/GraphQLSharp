using System.Text.Json.Serialization;
using System.Text.Json;

namespace GraphQLSharp;

#nullable enable

public static class Serializer
{
    public static readonly JsonSerializerOptions Options = new JsonSerializerOptions
    {
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        Converters = { new JsonStringEnumConverter() },
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public static readonly JsonSerializerOptions OptionsIndented = new JsonSerializerOptions(Options)
    {
        WriteIndented = true
    };

    public static JsonSerializerOptions GetOptions(bool indent)
    {
        return indent ? OptionsIndented : Options;
    }

    static Serializer()
    {
        Options.Converters.Add(new SafeDateTimeConverter());
        Options.Converters.Add(new SafeDateTimeOffsetConverter());
    }

    public static string Serialize(object obj, bool indent = false)
    {
        return JsonSerializer.Serialize(obj, obj.GetType(), GetOptions(indent));
    }

    public static object? Deserialize(string json, Type type, bool indent = false)
    {
        return JsonSerializer.Deserialize(json, type, GetOptions(indent));
    }

    public static T? Deserialize<T>(string json, bool indent = false)
    {
        return JsonSerializer.Deserialize<T>(json, GetOptions(indent));
    }
}