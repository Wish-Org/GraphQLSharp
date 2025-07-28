namespace GraphQLSharp;

public class NoOpInterceptor : IInterceptor
{
    public static readonly NoOpInterceptor Instance = new();

    private NoOpInterceptor() { }

    public Task<GraphQLResponse<T>> InterceptRequestAsync<T, TClientOptions>(GraphQLRequest request, TClientOptions defaultOptions, TClientOptions options, CancellationToken cancellationToken, Func<GraphQLRequest, CancellationToken, Task<GraphQLResponse<T>>> executeAsync) where TClientOptions : GraphQLClientOptions
    {
        return executeAsync(request, cancellationToken);
    }
}