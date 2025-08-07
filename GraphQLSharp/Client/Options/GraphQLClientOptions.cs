using System.Net.Http.Headers;
using System.Text.Json;

namespace GraphQLSharp;


public class GraphQLClientOptions : IGraphQLClientOptions<GraphQLClientOptions, GraphQLRequest>
{
    public Uri Uri { get; private set; }

    public GraphQLClientOptions(Uri uri)
    {
        Uri = uri ?? throw new ArgumentNullException(nameof(uri));
    }

    /// <summary>
    /// Whether to throw an exception if the GraphQL response contains errors.
    /// Defaults to true if unspecified.
    /// If set to false, the response will still contain the errors, but no exception will be thrown.
    /// </summary>
    public bool? ThrowOnGraphQLErrors { get; set; }

    /// <summary>
    /// An (optional) custom HttpClient to be used for sending requests.
    /// If null, a default shared HttpClient is used
    /// If set, you control the lifetime of the HttpClient.
    /// </summary>
    public HttpClient HttpClient { get; set; }

    /// <summary>
    /// An (optional) JSON serializer options to be used for serializing and deserializing GraphQL requests and responses.
    /// </summary>
    public JsonSerializerOptions JsonSerializerOptions { get; set; }

    /// <summary>
    /// An (optional) Interceptor to be used for this request.
    /// </summary>
    public IInterceptor<GraphQLRequest, GraphQLClientOptions> Interceptor { get; set; }

    public Action<HttpRequestHeaders> ConfigureHttpRequestHeaders { get; set; }
}
