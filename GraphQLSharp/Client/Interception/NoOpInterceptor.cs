namespace GraphQLSharp;

public class NoOpInterceptor : IInterceptor
{
    public static readonly NoOpInterceptor Instance = new();

    private NoOpInterceptor() { }

    public Task<GraphQLResponse<T>> InterceptRequestAsync<T>(GraphQLRequest request, GraphQLClientOptions options, Func<GraphQLRequest, GraphQLClientOptions, Task<GraphQLResponse<T>>> executeAsync, CancellationToken cancellationToken)
    {
        return executeAsync(request, options);
    }
}