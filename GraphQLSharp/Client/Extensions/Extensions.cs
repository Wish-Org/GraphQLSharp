using System.Text.Json;

namespace GraphQLSharp;

public interface IHasExtensions
{
    Dictionary<string, JsonElement> extensions { get; set; }
}

public static class Extensions
{
    public static TExtension GetExtension<TExtension>(this IHasExtensions hasExtensions, string key)
    {
        var extensions = hasExtensions.extensions;
        if (extensions == null || !extensions.TryGetValue(key, out var element))
            return default;

        return Serializer.Deserialize<TExtension>(element.GetRawText());
    }
}