namespace GraphQLSharp;

public class GraphQLHttpException : GraphQLException
{
    public GraphQLHttpException(GraphQLHttpError error, Exception ex)
        : base(error.Request, error.HttpResponse, $"""
                            GraphQL request failed with an HTTP error: {(error.errors != null ? string.Join("\n", error.errors) : "")}
                            Request: {error.Request}
                        """, ex)
    {
    }
}
