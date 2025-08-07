namespace GraphQLSharp;

/// <summary>
/// Interface for intercepting GraphQL requests.
/// Allows for custom processing of requests before they are sent and responses after they are received.
/// Implementations can be used to log requests, automatic retries, modify requests, handle errors, etc.
/// </summary>
public interface IInterceptor
{
    Task<GraphQLResponse<TData>> InterceptRequestAsync<TGraphQLRequest, TOptions, TData>(
                                TGraphQLRequest request,
                                TOptions options,
                                CancellationToken cancellationToken,
                                Func<TGraphQLRequest, CancellationToken,
                                Task<GraphQLResponse<TData>>> executeAsync)
                where TGraphQLRequest : GraphQLRequest
                where TOptions : class, IGraphQLClientOptions;
}

public interface IInterceptor<TRequest, TOptions> : IInterceptor
    where TRequest : GraphQLRequest
    where TOptions : class, IGraphQLClientOptions
{
    Task<GraphQLResponse<TData>> InterceptRequestAsync<TData>(TRequest request,
                                                            TOptions options,
                                                            CancellationToken cancellationToken,
                                                            Func<TRequest, CancellationToken, Task<GraphQLResponse<TData>>> executeAsync);
    Task<GraphQLResponse<TData>> IInterceptor.InterceptRequestAsync<TGraphQLRequest, TClientOptions, TData>(
                                    TGraphQLRequest request,
                                    TClientOptions options,
                                    CancellationToken cancellationToken,
                                    Func<TGraphQLRequest, CancellationToken,
                                    Task<GraphQLResponse<TData>>> executeAsync)
    {
        var shopifyRequest = request as TRequest;
        var shopifyOptions = options as TOptions;
        return this.InterceptRequestAsync(shopifyRequest, shopifyOptions, cancellationToken,
                                            (r, token) => executeAsync(r as TGraphQLRequest, token));
    }
}
