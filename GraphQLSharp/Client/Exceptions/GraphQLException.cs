namespace GraphQLSharp;

public class GraphQLException : Exception
{
    public readonly GraphQLRequest Request;

    public GraphQLException(GraphQLRequest request, string message, Exception ex = null)
     : base(message, ex)
    {
        Request = request;
    }
}