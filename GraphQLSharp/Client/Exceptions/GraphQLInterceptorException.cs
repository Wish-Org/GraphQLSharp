namespace GraphQLSharp;

public class GraphQLInterceptorException : Exception
{
    public readonly GraphQLRequest Request;
    public readonly IInterceptor Interceptor;

    public GraphQLInterceptorException(GraphQLRequest request, IInterceptor interceptor, Exception ex)
     : base("Interceptor error occurred", ex)
    {
        Request = request;
        Interceptor = interceptor;
    }
}