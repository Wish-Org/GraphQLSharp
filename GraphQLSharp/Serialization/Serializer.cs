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

    static Serializer()
    {
        Options.Converters.Add(new SafeDateTimeConverter());
        Options.Converters.Add(new SafeDateTimeOffsetConverter());
    }

    public static string Serialize(object obj)
    {
        return JsonSerializer.Serialize(obj, obj.GetType(), Options);
    }

    public static object? Deserialize(string json, Type type)
    {
        return JsonSerializer.Deserialize(json, type, Options);
    }

    public static T? Deserialize<T>(string json) where T : class
    {
        return JsonSerializer.Deserialize<T>(json, Options);
    }
}