namespace GraphQLSharp;

public class NoOpInterceptor : IInterceptor
{
    public static readonly NoOpInterceptor Instance = new();

    private NoOpInterceptor() { }

    public Task<GraphQLResponse<T>> InterceptRequestAsync<TGraphQLRequest, TClientOptions, T>(
        TGraphQLRequest request,
        TClientOptions defaultOptions,
        TClientOptions requestOptions,
        CancellationToken cancellationToken,
        Func<TGraphQLRequest, CancellationToken, Task<GraphQLResponse<T>>> executeAsync)
        where TGraphQLRequest : GraphQLRequest, new()
        where TClientOptions : GraphQLClientOptionsBase, IGraphQLClientOptions<TClientOptions>
    {
        return executeAsync(request, cancellationToken);
    }
}