namespace GraphQLSharp;

/// <summary>
/// Interface for intercepting GraphQL requests.
/// Allows for custom processing of requests before they are sent and responses after they are received.
/// Implementations can be used to log requests, automatic retries, modify requests, handle errors, etc.
/// </summary>
public interface IInterceptor
{
    Task<GraphQLResponse<TData>> InterceptRequestAsync<TGraphQLRequest, TClientOptions, TData>(
                                TGraphQLRequest request,
                                TClientOptions defaultOptions,
                                TClientOptions requestOptions,
                                CancellationToken cancellationToken,
                                Func<TGraphQLRequest, CancellationToken,
                                Task<GraphQLResponse<TData>>> executeAsync)
                where TGraphQLRequest : GraphQLRequest, new()
                where TClientOptions : GraphQLClientOptionsBase, IGraphQLClientOptions;
}