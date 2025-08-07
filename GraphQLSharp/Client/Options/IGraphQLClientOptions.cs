using System.Net.Http.Headers;
using System.Text.Json;

namespace GraphQLSharp;

public interface IGraphQLClientOptions<TSelf, TRequest>
    where TSelf : class, IGraphQLClientOptions<TSelf, TRequest>
    where TRequest : GraphQLRequest
{
    /// <summary>
    /// The URI of the GraphQL endpoint.
    /// </summary>
    Uri Uri { get; }

    /// <summary>
    /// Whether to throw an exception if the GraphQL response contains errors.
    /// Defaults to true if unspecified.
    /// If set to false, the response will still contain the errors, but no exception will be thrown.
    /// </summary>
    bool? ThrowOnGraphQLErrors { get; }

    /// <summary>
    /// An (optional) custom HttpClient to be used for sending requests.
    /// If null, a default shared HttpClient is used
    /// If set, you control the lifetime of the HttpClient.
    /// </summary>
    HttpClient HttpClient { get; }

    /// <summary>
    /// An (optional) JSON serializer options to be used for serializing and deserializing GraphQL requests and responses.
    /// </summary>
    JsonSerializerOptions JsonSerializerOptions { get; }

    /// <summary>
    /// An (optional) Interceptor to be used for this request.
    /// </summary>
    IInterceptor<TRequest, TSelf> Interceptor { get; }

    /// <summary>
    /// An (optional) configuration callback to modify the HttpRequestHeaders before sending the request.
    /// This can be used to set custom headers, authentication tokens, etc.
    /// </summary>
    Action<HttpRequestHeaders> ConfigureHttpRequestHeaders { get; }
}
