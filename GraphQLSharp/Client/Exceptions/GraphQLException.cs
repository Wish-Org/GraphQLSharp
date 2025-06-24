namespace GraphQLSharp;

public class GraphQLException : Exception
{
    public readonly GraphQLRequest Request;
    public readonly HttpResponseMessage HttpResponse;

    public GraphQLException(GraphQLRequest request, HttpResponseMessage httpResponse, string message, Exception ex = null)
     : base(message, ex)
    {
        HttpResponse = httpResponse;
        Request = request;
    }
}