using System.Net.Http.Headers;

namespace GraphQLSharp;

public class GraphQLClientOptions
{
    /// <summary>
    /// Whether to throw an exception if the GraphQL response contains errors. Defaults to TRUE.
    /// If set to false, the response will still contain the errors, but no exception will be thrown.
    /// </summary>
    public bool ThrowOnGraphQLErrors { get; init; } = true;

    public Uri Uri { get; init; }

    public HttpClient HttpClient { get; init; }

    public Action<HttpRequestHeaders> ConfigureHttpRequestHeaders { get; init; }
}