using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Net.Http.Json;

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

    public Task<GraphQLResponse<T>> ExecuteAsync<T>([StringSyntax("GraphQL")] string query, GraphQLClientOptions options = null, CancellationToken cancellationToken = default)
    {
        return ExecuteAsync<T>(new GraphQLRequest { query = query }, options, cancellationToken);
    }

    public async Task<GraphQLResponse<T>> ExecuteAsync<T>(GraphQLRequest request, GraphQLClientOptions options = null, CancellationToken cancellationToken = default)
    {
        HttpResponseMessage httpResponse = null;
        try
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

            httpResponse = await httpClient.SendAsync(requestMessage, cancellationToken);

            try
            {
                httpResponse.EnsureSuccessStatusCode();
            }
            catch (Exception httpEx)
            {
                throw new GraphQLHttpException(request, httpResponse, httpEx);
            }

            GraphQLResponse<T> res;
            try
            {
                res = await httpResponse.Content.ReadFromJsonAsync<GraphQLResponse<T>>(Serializer.Options, cancellationToken);
                if (res == null)
                    throw new GraphQLException(request, httpResponse, $"Failed to deserialize null GraphQL response. Request: {request}");
            }
            catch (Exception jsonEx)
            {
                throw new GraphQLException(request, httpResponse, $"Failed to deserialize GraphQL response. Request: {request}", jsonEx);
            }

            res.Request = request;
            res.HttpResponse = httpResponse;

            bool throwOnGraphQLErrors = options?.ThrowOnGraphQLErrors ?? _defaultOptions?.ThrowOnGraphQLErrors ?? true;
            if (throwOnGraphQLErrors)
                res.ThrowIfAnyError();

            return res;
        }
        catch (Exception ex) when (ex is not GraphQLException)
        {
            throw new GraphQLException(request, httpResponse, $"Unexpected GraphQL error: {request}", ex);
        }
    }
}