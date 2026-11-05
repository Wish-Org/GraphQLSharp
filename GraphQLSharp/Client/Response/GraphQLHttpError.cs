using System.Text.Json.Serialization;

namespace GraphQLSharp;

public class GraphQLHttpError : IGraphQLObject
{
    [JsonIgnore]
    public GraphQLRequest Request { get; internal set; }

    [JsonIgnore]
    public HttpResponse HttpResponse { get; internal set; }

    [JsonConverter(typeof(GraphQLHttpErrorMessageConverter))]
    public string errors { get; set; }
}
