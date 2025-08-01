namespace GraphQLSharp;

public class NoOpInterceptor : IInterceptor
{
    public static readonly NoOpInterceptor Instance = new();

    private NoOpInterceptor() { }

    public Task<GraphQLResponse<T>> InterceptRequestAsync<TGraphQLRequest, TClientOptions, T>(
        TGraphQLRequest request,
        TClientOptions options,
        CancellationToken cancellationToken,
        Func<TGraphQLRequest, CancellationToken, Task<GraphQLResponse<T>>> executeAsync)
        where TGraphQLRequest : GraphQLRequest
        where TClientOptions : IGraphQLClientOptions
    {
        return executeAsync(request, cancellationToken);
    }
}