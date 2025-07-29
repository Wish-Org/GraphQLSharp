using System.Text.Json;

namespace GraphQLSharp;

public class GraphQLError : IHasExtensions
{
    public string message { get; set; }
    public List<GraphQLErrorLocation> locations { get; set; }
    public List<object> path { get; set; }
    public Dictionary<string, JsonElement> extensions { get; set; }

    public override string ToString()
    {
        return $"""
            Error: {message}
            Locations: {string.Join(", ", (locations ?? []).Select(l => $"{l.line}:{l.column}"))}
            """;
    }
}
