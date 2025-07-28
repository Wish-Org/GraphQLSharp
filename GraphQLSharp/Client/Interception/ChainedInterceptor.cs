namespace GraphQLSharp;

public class ChainedInterceptor : IInterceptor
{
    private List<IInterceptor> _interceptors = new List<IInterceptor>();

    public ChainedInterceptor(IInterceptor innerMostInterceptor)
    {
        this._interceptors.Add(innerMostInterceptor);
    }

    public ChainedInterceptor Wrap(IInterceptor nextInterceptor)
    {
        _interceptors.Add(nextInterceptor);
        return this;
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
