using System.Net.Http.Headers;

namespace GraphQLSharp;


public class GraphQLClientOptions : GraphQLClientOptionsBase, IGraphQLClientOptions<GraphQLClientOptions>
{
    private readonly Uri _uri;

    public GraphQLClientOptions(Uri uri)
    {
        _uri = uri ?? throw new ArgumentNullException(nameof(uri));
    }

    public Action<HttpRequestHeaders> ConfigureHttpRequestHeaders { get; set; }

    static Action<HttpRequestHeaders> IGraphQLClientOptions<GraphQLClientOptions>.GetConfigureHttpRequestHeaders(GraphQLClientOptions defaultOptions, GraphQLClientOptions requestOptions)
    {
        return requestOptions.ConfigureHttpRequestHeaders ?? defaultOptions.ConfigureHttpRequestHeaders;
    }

    static Uri IGraphQLClientOptions<GraphQLClientOptions>.GetUri(GraphQLClientOptions defaultOptions, GraphQLClientOptions requestOptions)
    {
        return requestOptions._uri ?? defaultOptions._uri;
    }
}
