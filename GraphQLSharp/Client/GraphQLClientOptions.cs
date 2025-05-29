using System.Net.Http.Headers;

namespace GraphQLSharp;

public class GraphQLClientOptions
{
    public required Uri Uri { get; init; }

    public HttpClient HttpClient { get; init; }

    public ProductInfoHeaderValue UserAgentRequestHeader { get; init; }
}