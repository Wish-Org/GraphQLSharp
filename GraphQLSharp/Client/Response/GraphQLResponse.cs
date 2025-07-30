using System.Text.Json;
using System.Text.Json.Serialization;

namespace GraphQLSharp;

public class GraphQLResponse<T> : GraphQLResponse
{
    public new T data
    {
        get => (T)base.data;
        set => base.data = value;
    }
}

public class GraphQLResponse : IHasExtensions
{
    [JsonIgnore]
    public GraphQLRequest Request { get; internal set; }

    [JsonIgnore]
    public HttpResponse HttpResponse { get; internal set; }

    public object data { get; set; }

    public List<GraphQLError> errors { get; set; }

    public Dictionary<string, JsonElement> extensions { get; set; }

    public void ThrowIfAnyError()
    {
        if (errors?.Count > 0)
            throw new GraphQLErrorsException(this);
    }
}
