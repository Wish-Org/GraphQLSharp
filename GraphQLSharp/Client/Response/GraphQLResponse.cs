using System.Text.Json;

namespace GraphQLSharp;

public class GraphQLResponse<T>
{
    public T data { get; set; }
    public List<GraphQLError> errors { get; set; }
    public Dictionary<string, JsonElement> extensions { get; set; }
}
