namespace GraphQLSharp;

public class ChainedInterceptor<TRequest, TOptions> : ChainedInterceptor, IInterceptor<TRequest, TOptions>
    where TRequest : GraphQLRequest
    where TOptions : class, IGraphQLClientOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ChainedInterceptor"/> class with the specified interceptors.
    /// </summary>
    /// <param name="interceptors">
    /// An array of interceptors to chain together.
    /// The first interceptor in the array will be executed first (inner most), followed by the second, and so on.
    /// </param>
    public ChainedInterceptor(params IInterceptor[] interceptors) : base(interceptors)
    {
    }

    public Task<GraphQLResponse<TData>> InterceptRequestAsync<TData>(TRequest request, TOptions options, CancellationToken cancellationToken, Func<TRequest, CancellationToken, Task<GraphQLResponse<TData>>> executeAsync)
    {
        return this.InterceptRequestAsync<TRequest, TOptions, TData>(request, options, cancellationToken, executeAsync);
    }
}

public class ChainedInterceptor : IInterceptor
{
    private IInterceptor[] _interceptors;


    /// <summary>
    /// Initializes a new instance of the <see cref="ChainedInterceptor"/> class with the specified interceptors.
    /// </summary>
    /// <param name="interceptors">
    /// An array of interceptors to chain together.
    /// The first interceptor in the array will be executed first (inner most), followed by the second, and so on.
    /// </param>
    public ChainedInterceptor(params IInterceptor[] interceptors)
    {
        this._interceptors = interceptors;
    }

    public async Task<GraphQLResponse<TData>> InterceptRequestAsync<TGraphQLRequest, TClientOptions, TData>(TGraphQLRequest request,
                                                                                                            TClientOptions options,
                                                                                                            CancellationToken cancellationToken,
                                                                                                            Func<TGraphQLRequest, CancellationToken, Task<GraphQLResponse<TData>>> executeAsync)
        where TGraphQLRequest : GraphQLRequest
        where TClientOptions : class, IGraphQLClientOptions
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
