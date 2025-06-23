namespace GraphQLSharp;

public class GraphQLErrorsException : GraphQLException
{
    public readonly IEnumerable<GraphQLError> Errors;

    public GraphQLErrorsException(GraphQLRequest request, List<GraphQLError> errors)
        : base(request, $"""
                        GraphQL request returned errors:
                        Request: {request}
                        Errors: {string.Join("\n", errors.Select(e => e.ToString()))}
                        """)
    {
        this.Errors = errors;
    }
}