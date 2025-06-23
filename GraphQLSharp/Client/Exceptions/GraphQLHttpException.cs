namespace GraphQLSharp;

public class GraphQLHttpException : GraphQLException
{
    public GraphQLHttpException(GraphQLRequest request, Exception ex)
        : base(request, $"""
                            GraphQL request failed with an HTTP error:
                            Request: {request}
                        """, ex)
    {
    }
}