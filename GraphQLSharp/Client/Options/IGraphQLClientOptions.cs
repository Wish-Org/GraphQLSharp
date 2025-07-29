using System.Net.Http.Headers;

namespace GraphQLSharp;

public interface IGraphQLClientOptions
{
    Uri Uri { get; }

    /// <summary>
    /// An (optional) configuration callback to modify the HttpRequestHeaders before sending the request.
    /// This can be used to set custom headers, authentication tokens, etc.
    /// </summary>
    Action<HttpRequestHeaders> ConfigureHttpRequestHeaders { get; }
}
