namespace GraphQLSharp;

/// <summary>
/// Interface for intercepting GraphQL requests.
/// Allows for custom processing of requests before they are sent and responses after they are received.
/// Implementations can be used to log requests, automatic retries, modify requests, handle errors, etc.
/// </summary>
public interface IInterceptor<TRequest, TOptions> : IInterceptor
    where TRequest : GraphQLRequest
    where TOptions : class, IGraphQLClientOptions<TOptions, TRequest>
{
    Task<GraphQLResponse<TData>> InterceptRequestAsync<TData>(TRequest request,
                                                            TOptions options,
                                                            CancellationToken cancellationToken,
                                                            Func<TRequest, CancellationToken, Task<GraphQLResponse<TData>>> executeAsync);
}

public interface IInterceptor
{
}
