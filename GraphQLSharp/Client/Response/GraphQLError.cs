using System.Text.Json;

namespace GraphQLSharp;

public class GraphQLError
{
    public string message { get; set; }
    public List<GraphQLErrorLocation> locations { get; set; }
    public List<object> path { get; set; }
    public Dictionary<string, JsonElement> extensions { get; set; }
}
