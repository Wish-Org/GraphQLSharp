using System.Net.Http.Headers;
using System.Text.Json;

namespace GraphQLSharp;


public class GraphQLClientOptions : GraphQLClientOptionsBase, IGraphQLClientOptions
{
    private readonly Uri _uri;

    public GraphQLClientOptions(Uri uri)
    {
        _uri = uri ?? throw new ArgumentNullException(nameof(uri));
    }

    public Action<HttpRequestHeaders> ConfigureHttpRequestHeaders { get; set; }

    Uri IGraphQLClientOptions.Uri => _uri;

    Action<HttpRequestHeaders> IGraphQLClientOptions.ConfigureHttpRequestHeaders => ConfigureHttpRequestHeaders;
}

public interface IGraphQLClientOptions
{
    Uri Uri { get; }

    /// <summary>
    /// An (optional) configuration callback to modify the HttpRequestHeaders before sending the request.
    /// This can be used to set custom headers, authentication tokens, etc.
    /// </summary>
    Action<HttpRequestHeaders> ConfigureHttpRequestHeaders { get; }
}

/// <summary>
/// Options for configuring GraphQL requests.
/// Can be set either globally on the GraphQLClient or per request.
/// If both are set, the per request options will override the global options.
/// </summary>
public abstract class GraphQLClientOptionsBase
{
    /// <summary>
    /// Whether to throw an exception if the GraphQL response contains errors. Defaults to TRUE.
    /// If set to false, the response will still contain the errors, but no exception will be thrown.
    /// </summary>
    public bool ThrowOnGraphQLErrors { get; set; } = true;

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
    public IInterceptor Interceptor { get; set; }
}
