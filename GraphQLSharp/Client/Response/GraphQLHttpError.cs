using System.Text.Json.Serialization;

namespace GraphQLSharp;

public class GraphQLHttpError : IGraphQLObject
{
    [JsonIgnore]
    public GraphQLRequest Request { get; internal set; }

    [JsonIgnore]
    public HttpResponse HttpResponse { get; internal set; }

    public string errors { get; set; }
}
