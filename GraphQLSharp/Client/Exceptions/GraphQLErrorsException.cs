using System.Text.Json;

namespace GraphQLSharp;

public class GraphQLErrorsException : GraphQLException, IHasExtensions
{
    public readonly IEnumerable<GraphQLError> errors;

    public Dictionary<string, JsonElement> extensions { get; set; }

    public GraphQLErrorsException(GraphQLRequest request, HttpResponse httpResponse, List<GraphQLError> errors, Dictionary<string, JsonElement> extensions)
        : base(request, httpResponse, $"""
                        GraphQL request returned errors:
                        Request: {request}
                        Errors: {string.Join("\n", errors.Select(e => e.ToString()))}
                        """)
    {
        this.errors = errors;
        this.extensions = extensions;
    }
}