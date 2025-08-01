using System.Net.Http.Headers;

namespace GraphQLSharp;

public interface IGraphQLClientOptions<TClientOptions> where TClientOptions : GraphQLClientOptionsBase, IGraphQLClientOptions<TClientOptions>
{
    static abstract Uri GetUri(TClientOptions defaultOptions, TClientOptions requestOptions);
    /// <summary>
    /// An (optional) configuration callback to modify the HttpRequestHeaders before sending the request.
    /// This can be used to set custom headers, authentication tokens, etc.
    /// </summary>
    static abstract Action<HttpRequestHeaders> GetConfigureHttpRequestHeaders(TClientOptions defaultOptions, TClientOptions requestOptions);
}
