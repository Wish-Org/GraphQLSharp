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
