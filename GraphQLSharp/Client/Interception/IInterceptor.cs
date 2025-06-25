namespace GraphQLSharp;

/// <summary>
/// Interface for intercepting GraphQL requests.
/// Allows for custom processing of requests before they are sent and responses after they are received.
/// Implementations can be used to log requests, automatic retries, modify requests, handle errors, etc.
/// </summary>
public interface IInterceptor
{
    Task<GraphQLResponse<T>> InterceptRequestAsync<T>(GraphQLRequest request,
                                                      GraphQLRequestOptions options,
                                                      Func<GraphQLRequest, GraphQLRequestOptions, Task<GraphQLResponse<T>>> executeAsync,
                                                      CancellationToken cancellationToken);
}