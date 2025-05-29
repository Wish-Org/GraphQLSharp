using System.Net.Http.Headers;

namespace GraphQLSharp;

public class GraphQLClient
{
    private static readonly HttpClient _defaultHttpClient = new();

    private static readonly ProductInfoHeaderValue _defaultUserAgent = new(typeof(GraphQLClient).Assembly.GetName().Name, typeof(GraphQLClient).Assembly.GetName().Version.ToString());

    private readonly GraphQLClientOptions _options;

    public GraphQLClient(GraphQLClientOptions options)
    {
        _options = options;
    }
}