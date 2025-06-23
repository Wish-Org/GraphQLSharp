using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace GraphQLSharp;

public class GraphQLClient
{
    private static readonly HttpClient _defaultHttpClient = new();

    private static readonly ProductInfoHeaderValue _defaultUserAgent = new(typeof(GraphQLClient).Assembly.GetName().Name!, typeof(GraphQLClient).Assembly.GetName().Version!.ToString());

    private readonly GraphQLClientOptions _defaultOptions;

    public GraphQLClient(GraphQLClientOptions defaultOptions = null)
    {
        _defaultOptions = defaultOptions;
    }

    public async Task<GraphQLResponse<T>> RequestAsync<T>(GraphQLRequest request, GraphQLClientOptions options = null, CancellationToken cancellationToken = default)
    {
        var httpClient = options?.HttpClient ?? _defaultOptions.HttpClient ?? _defaultHttpClient;
        var uri = options?.Uri ?? _defaultOptions.Uri;
        using var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = uri,
            Content = JsonContent.Create(request, options: Serializer.Options),
        };

        requestMessage.Headers.UserAgent.Add(_defaultUserAgent);
        _defaultOptions?.ConfigureHttpRequestHeaders?.Invoke(requestMessage.Headers);
        options?.ConfigureHttpRequestHeaders?.Invoke(requestMessage.Headers);

        var response = await httpClient.SendAsync(requestMessage, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<GraphQLResponse<T>>(Serializer.Options, cancellationToken)
            ?? throw new JsonException("Failed to deserialize GraphQL response");
    }
}