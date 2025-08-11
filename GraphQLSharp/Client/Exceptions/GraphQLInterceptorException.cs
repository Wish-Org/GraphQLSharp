namespace GraphQLSharp;

public class GraphQLInterceptorException : GraphQLException
{
    public readonly IInterceptor Interceptor;

    public GraphQLInterceptorException(GraphQLRequest request, IInterceptor interceptor, Exception ex)
     : base(request, null, "Interceptor error occurred", ex)
    {
        Interceptor = interceptor;
    }
}