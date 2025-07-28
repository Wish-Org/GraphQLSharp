using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace GraphQLSharp;

public class GraphQLClient<TQueryRoot, TMutationRoot, TClientOptions> : GraphQLClient<TQueryRoot, TClientOptions>
    where TQueryRoot : class
    where TMutationRoot : class
    where TClientOptions : GraphQLClientOptions
{
    public GraphQLClient(TClientOptions defaultOptions = null) : base(defaultOptions)
    {
    }

    public Task<GraphQLResponse<TMutationRoot>> ExecuteMutationAsync([StringSyntax("GraphQL")] string query, TClientOptions options = null, CancellationToken cancellationToken = default)
    {
        return ExecuteAsync<TMutationRoot>(query, options, cancellationToken);
    }

    public Task<GraphQLResponse<TMutationRoot>> ExecuteMutationAsync(GraphQLRequest request, TClientOptions options = null, CancellationToken cancellationToken = default)
    {
        return ExecuteAsync<TMutationRoot>(request, options, cancellationToken);
    }
}

public class GraphQLClient<TQueryRoot, TClientOptions> : GraphQLClient<TClientOptions>
    where TQueryRoot : class
    where TClientOptions : GraphQLClientOptions
{
    public GraphQLClient(TClientOptions defaultOptions = null) : base(defaultOptions)
    {
    }

    public Task<GraphQLResponse<TQueryRoot>> ExecuteQueryAsync([StringSyntax("GraphQL")] string query, TClientOptions options = null, CancellationToken cancellationToken = default)
    {
        return ExecuteAsync<TQueryRoot>(query, options, cancellationToken);
    }

    public Task<GraphQLResponse<TQueryRoot>> ExecuteQueryAsync(GraphQLRequest request, TClientOptions options = null, CancellationToken cancellationToken = default)
    {
        return ExecuteAsync<TQueryRoot>(request, options, cancellationToken);
    }
}

public class GraphQLCLient : GraphQLClient<GraphQLClientOptions>
{
    public GraphQLCLient(GraphQLClientOptions defaultOptions = null) : base(defaultOptions)
    {
    }
}

public class GraphQLClient<TClientOptions>
    where TClientOptions : GraphQLClientOptions
{
    private static readonly HttpClient _defaultHttpClient = new();

    private static readonly ProductInfoHeaderValue _defaultUserAgent = new(typeof(GraphQLClient<TClientOptions>).Assembly.GetName().Name!, typeof(GraphQLClient<TClientOptions>).Assembly.GetName().Version!.ToString());

    private readonly TClientOptions _defaultOptions;

    public GraphQLClient(TClientOptions defaultOptions = null)
    {
        _defaultOptions = defaultOptions;
    }

    public Task<GraphQLResponse<JsonElement>> ExecuteAsync([StringSyntax("GraphQL")] string query, TClientOptions options = null, CancellationToken cancellationToken = default)
    {
        return ExecuteAsync<JsonElement>(query, options, cancellationToken);
    }

    public Task<GraphQLResponse<T>> ExecuteAsync<T>([StringSyntax("GraphQL")] string query, TClientOptions options = null, CancellationToken cancellationToken = default)
    {
        return ExecuteAsync<T>(new GraphQLRequest { query = query }, options, cancellationToken);
    }

    public Task<GraphQLResponse<JsonElement>> ExecuteAsync(GraphQLRequest request, TClientOptions options = null, CancellationToken cancellationToken = default)
    {
        //returing JsonElement and not JsonDocument because JsonDocument is disposable and we don't want to force the user to dispose it
        return ExecuteAsync<JsonElement>(request, options, cancellationToken);
    }

    public async Task<GraphQLResponse<T>> ExecuteAsync<T>(GraphQLRequest request, TClientOptions options = null, CancellationToken cancellationToken = default)
    {
        var interceptor = options?.Interceptor ?? _defaultOptions?.Interceptor ?? NoOpInterceptor.Instance;

        try
        {
            return await interceptor.InterceptRequestAsync(request, _defaultOptions, options, cancellationToken,
                                                            //the interceptor may pass through a different request or cancellationToken
                                                            async (req, token) => await ExecuteCoreAsync<T>(req, options, token));
        }
        catch (Exception ex) when (ex is not GraphQLException)
        {
            throw new GraphQLInterceptorException(request, interceptor, ex);
        }
    }

    private async Task<GraphQLResponse<T>> ExecuteCoreAsync<T>(GraphQLRequest request, TClientOptions options = null, CancellationToken cancellationToken = default)
    {
        HttpResponse httpResponse = null;
        try
        {
            using HttpRequestMessage requestMessage = CreateHttpRequest(request, options);

            var httpClient = options?.HttpClient ?? _defaultOptions?.HttpClient ?? _defaultHttpClient;
            using var httpResponseMsg = await httpClient.SendAsync(requestMessage, cancellationToken);
            //httpResponseMsg needs to disposed so we create a small copy of basic information
            httpResponse = new HttpResponse(httpResponseMsg);
            try
            {
                httpResponseMsg.EnsureSuccessStatusCode();
            }
            catch (Exception httpEx)
            {
                throw new GraphQLHttpException(request, httpResponse, httpEx);
            }

            GraphQLResponse<T> res;
            try
            {
                res = await httpResponseMsg.Content.ReadFromJsonAsync<GraphQLResponse<T>>(options?.JsonSerializerOptions ?? _defaultOptions?.JsonSerializerOptions ?? Serializer.Options, cancellationToken);
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

    protected virtual void ValidateOptions(TClientOptions defaultOptions, TClientOptions options)
    {
    }

    private HttpRequestMessage CreateHttpRequest(GraphQLRequest request, TClientOptions options)
    {
        ValidateOptions(_defaultOptions, options);
        var uri = options?.Uri ?? _defaultOptions?.Uri ?? throw new ArgumentNullException($"{nameof(options)}.{nameof(options.Uri)}");
        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = uri,
            Content = JsonContent.Create(request, options: options?.JsonSerializerOptions ?? _defaultOptions?.JsonSerializerOptions ?? Serializer.Options),
        };

        requestMessage.Headers.UserAgent.Add(_defaultUserAgent);
        _defaultOptions?.ConfigureHttpRequestHeaders?.Invoke(requestMessage.Headers);
        options?.ConfigureHttpRequestHeaders?.Invoke(requestMessage.Headers);
        return requestMessage;
    }
}