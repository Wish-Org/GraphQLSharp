using System.Net.Http.Headers;

namespace GraphQLSharp;

public class GraphQLRequestOptions
{
    /// <summary>
    /// Whether to throw an exception if the GraphQL response contains errors. Defaults to TRUE.
    /// If set to false, the response will still contain the errors, but no exception will be thrown.
    /// </summary>
    public bool ThrowOnGraphQLErrors { get; set; } = true;

    public Uri Uri { get; set; }

    public HttpClient HttpClient { get; set; }

    public Action<HttpRequestHeaders> ConfigureHttpRequestHeaders { get; set; }

    public IInterceptor Interceptor { get; set; }
}
