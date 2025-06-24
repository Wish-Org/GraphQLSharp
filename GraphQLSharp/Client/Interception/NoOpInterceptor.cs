namespace GraphQLSharp;

public class NoOpInterceptor : IInterceptor
{
    public static readonly NoOpInterceptor Instance = new();

    private NoOpInterceptor() { }

    public Task<GraphQLResponse<T>> InterceptRequestAsync<T>(GraphQLRequest request, GraphQLRequestOptions options, Func<GraphQLRequest, GraphQLRequestOptions, Task<GraphQLResponse<T>>> executeAsync, CancellationToken cancellationToken)
    {
        return executeAsync(request, options);
    }
}