using System.Net.Http.Headers;

namespace GraphQLSharp;

/// <summary>
/// Options for configuring GraphQL requests.
/// Can be set either globally on the GraphQLClient or per request.
/// If both are set, the per request options will override the global options.
/// </summary>
public class GraphQLRequestOptions
{
    /// <summary>
    /// Whether to throw an exception if the GraphQL response contains errors. Defaults to TRUE.
    /// If set to false, the response will still contain the errors, but no exception will be thrown.
    /// </summary>
    public bool ThrowOnGraphQLErrors { get; set; } = true;

    public Uri Uri { get; set; }

    /// <summary>
    /// HttpClient to be used/
    /// If null, a default shared HttpClient is used
    /// If set, you control the lifetime of the HttpClient.
    /// </summary>
    public HttpClient HttpClient { get; set; }

    /// <summary>
    /// A configuration callback to modify the HttpRequestHeaders before sending the request.
    /// This can be used to set custom headers, authentication tokens, etc.
    /// </summary>
    public Action<HttpRequestHeaders> ConfigureHttpRequestHeaders { get; set; }

    /// <summary>
    /// Interceptor to be used for this request.
    /// </summary>
    public IInterceptor Interceptor { get; set; }
}
