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
    /// An array of interceptors to chain together, from innermost to outermost.
    /// The first interceptor is the innermost (closest to the HTTP call) and the last is the outermost.
    /// For interceptors [A, B, C], a request runs C, then B, then A, then the HTTP call, and the
    /// response returns through A, then B, then C.
    /// Header callbacks are applied in the order the request flows: C's first, then B's, then A's,
    /// so an inner interceptor's headers are applied after (and can override) an outer one's.
    /// </param>
    public ChainedInterceptor(params IInterceptor<TRequest, TOptions>[] interceptors)
    {
        this._interceptors = interceptors;
    }

    public async Task<GraphQLResponse<TData>> InterceptRequestAsync<TData>(TRequest request, TOptions options, CancellationToken cancellationToken, ExecuteRequestAsync<TRequest, TData> executeAsync)
    {
        foreach (var interceptor in _interceptors)
        {
            var capturedInterceptor = interceptor;
            var capturedExecuteAsync = executeAsync;
            executeAsync = (req, configureHttpRequestHeaders, ct) => capturedInterceptor.InterceptRequestAsync(req, options, ct,
                (innerRequest, configureInnerHttpRequestHeaders, innerCancellationToken) => capturedExecuteAsync(innerRequest, headers =>
                {
                    // Apply callbacks in request order, from outermost to innermost.
                    configureHttpRequestHeaders?.Invoke(headers);
                    configureInnerHttpRequestHeaders?.Invoke(headers);
                }, innerCancellationToken));
        }

        return await executeAsync(request, null, cancellationToken);
    }
}
