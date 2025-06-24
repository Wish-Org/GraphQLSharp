namespace GraphQLSharp;

public class GraphQLHttpException : GraphQLException
{
    public GraphQLHttpException(GraphQLRequest request, HttpResponseMessage httpResponse, Exception ex)
        : base(request, httpResponse, $"""
                            GraphQL request failed with an HTTP error:
                            Request: {request}
                        """, ex)
    {
    }
}