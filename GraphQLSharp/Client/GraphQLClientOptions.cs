using System.Net.Http.Headers;

namespace GraphQLSharp;

public class GraphQLClientOptions
{
    public bool DoNotThrowOnGraphQLErrors { get; init; }

    public Uri Uri { get; init; }

    public HttpClient HttpClient { get; init; }

    public Action<HttpRequestHeaders> ConfigureHttpRequestHeaders { get; init; }
}