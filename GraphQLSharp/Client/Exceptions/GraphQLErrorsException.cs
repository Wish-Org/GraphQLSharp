namespace GraphQLSharp;

public class GraphQLErrorsException : GraphQLException
{
    public readonly GraphQLResponse response;

    public GraphQLErrorsException(GraphQLResponse response)
        : base(response.Request, response.HttpResponse, $"""
                        GraphQL request returned errors:
                        Request: {response.Request}
                        Errors: {string.Join("\n", response.errors.Select(e => e.ToString()))}
                        """)
    {
    }
}