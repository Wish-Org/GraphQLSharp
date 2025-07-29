using System.Text.Json;

namespace GraphQLSharp;

public interface IHasExtensions
{
    Dictionary<string, JsonElement> extensions { get; set; }

    public TExtension GetExtension<TExtension>(string key)
    {
        if (extensions == null || !extensions.TryGetValue(key, out var element))
            return default;

        return Serializer.Deserialize<TExtension>(element.GetRawText());
    }
}