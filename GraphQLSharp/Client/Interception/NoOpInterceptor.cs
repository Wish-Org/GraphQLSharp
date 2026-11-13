namespace GraphQLSharp;

public class NoOpInterceptor<TRequest, TOptions> : IInterceptor<TRequest, TOptions>
    where TRequest : GraphQLRequest
    where TOptions : class, IGraphQLClientOptions<TOptions, TRequest>
{
    public static readonly NoOpInterceptor<TRequest, TOptions> Instance = new();

    private NoOpInterceptor() { }

    public Task<GraphQLResponse<TData>> InterceptRequestAsync<TData>(TRequest request, TOptions options, CancellationToken cancellationToken, ExecuteRequestAsync<TRequest, TData> executeAsync)
    {
        return executeAsync(request, null, cancellationToken);
    }
}