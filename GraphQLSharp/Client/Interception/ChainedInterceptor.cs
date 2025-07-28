namespace GraphQLSharp;

public class ChainedInterceptor : IInterceptor
{
    private IInterceptor[] _interceptors;


    /// <summary>
    /// Initializes a new instance of the <see cref="ChainedInterceptor"/> class with the specified interceptors.
    /// </summary>
    /// <param name="interceptors">
    /// An array of interceptors to chain together.
    /// The first interceptor in the array will be executed first, followed by the second, and so on.
    /// </param>
    public ChainedInterceptor(params IInterceptor[] interceptors)
    {
        this._interceptors = interceptors;
    }

    public async Task<GraphQLResponse<TData>> InterceptRequestAsync<TGraphQLRequest, TClientOptions, TData>(TGraphQLRequest request, TClientOptions defaultOptions, TClientOptions options, CancellationToken cancellationToken, Func<TGraphQLRequest, CancellationToken, Task<GraphQLResponse<TData>>> executeAsync)
        where TGraphQLRequest : GraphQLRequest, new()
        where TClientOptions : GraphQLClientOptions
    {
        foreach (var interceptor in _interceptors)
        {
            var capturedInterceptor = interceptor;
            var capturedExecuteAsync = executeAsync;
            executeAsync = (req, ct) => capturedInterceptor.InterceptRequestAsync(req, defaultOptions, options, ct, capturedExecuteAsync);
        }

        return await executeAsync(request, cancellationToken);
    }
}
