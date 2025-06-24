namespace GraphQLSharp;

public class GraphQLException : Exception
{
    public readonly GraphQLRequest Request;
    public readonly HttpResponse HttpResponse;

    public GraphQLException(GraphQLRequest request, HttpResponse httpResponse, string message, Exception ex = null)
     : base(message, ex)
    {
        HttpResponse = httpResponse;
        Request = request;
    }
}