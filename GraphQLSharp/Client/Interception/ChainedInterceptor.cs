namespace GraphQLSharp;

public class ChainedInterceptor<TRequest, TOptions> : IInterceptor<TRequest, TOptions>
    where TRequest : GraphQLRequest
    where TOptions : class, IGraphQLClientOptions<TOptions, TRequest>
{
    private IInterceptor<TRequest, TOptions>[] _interceptors;


    /// <summary>
    /// Initializes a new instance of the <see cref="ChainedInterceptor{TRequest, TOptions}"/> class with the specified interceptors.
    /// </summary>
    /// <param name="interceptors">
    /// An array of interceptors to chain together.
    /// The first interceptor in the array will be executed first (inner most), followed by the second, and so on.
    /// </param>
    public ChainedInterceptor(params IInterceptor<TRequest, TOptions>[] interceptors)
    {
        this._interceptors = interceptors;
    }

    public async Task<GraphQLResponse<TData>> InterceptRequestAsync<TData>(TRequest request, TOptions options, CancellationToken cancellationToken, Func<TRequest, CancellationToken, Task<GraphQLResponse<TData>>> executeAsync)
    {
        foreach (var interceptor in _interceptors)
        {
            var capturedInterceptor = interceptor;
            var capturedExecuteAsync = executeAsync;
            executeAsync = (req, ct) => capturedInterceptor.InterceptRequestAsync(req, options, ct, capturedExecuteAsync);
        }

        return await executeAsync(request, cancellationToken);
    }
}
