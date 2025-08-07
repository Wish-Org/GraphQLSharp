using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace GraphQLSharp;

public class GraphQLClient<TGraphQLRequest, TClientOptions, TQueryRoot, TMutationRoot> : GraphQLClient<TGraphQLRequest, TClientOptions, TQueryRoot>
    where TGraphQLRequest : GraphQLRequest
    where TClientOptions : class, IGraphQLClientOptions
    where TQueryRoot : class
    where TMutationRoot : class
{
    public GraphQLClient(TClientOptions options) : base(options)
    {
    }

    public Task<GraphQLResponse<TMutationRoot>> MutationAsync(TGraphQLRequest request, CancellationToken cancellationToken = default)
    {
        return ExecuteAsync<TMutationRoot>(request, cancellationToken);
    }
}

public class GraphQLClient<TGraphQLRequest, TClientOptions, TQueryRoot> : GraphQLClient<TGraphQLRequest, TClientOptions>
    where TGraphQLRequest : GraphQLRequest
    where TQueryRoot : class
    where TClientOptions : class, IGraphQLClientOptions
{
    public GraphQLClient(TClientOptions options) : base(options)
    {
    }

    public Task<GraphQLResponse<TQueryRoot>> QueryAsync(TGraphQLRequest request, CancellationToken cancellationToken = default)
    {
        return ExecuteAsync<TQueryRoot>(request, cancellationToken);
    }
}

public class GraphQLCLient : GraphQLClient<GraphQLRequest, GraphQLClientOptions>
{
    public GraphQLCLient(GraphQLClientOptions options) : base(options)
    {
    }
}

public class GraphQLClient<TGraphQLRequest, TClientOptions>
    where TGraphQLRequest : GraphQLRequest
    where TClientOptions : class, IGraphQLClientOptions
{
    private static readonly HttpClient _defaultHttpClient = new();

    private static readonly ProductInfoHeaderValue _defaultUserAgent = new(typeof(GraphQLClient<TGraphQLRequest, TClientOptions>).Assembly.GetName().Name!, typeof(GraphQLClient<TGraphQLRequest, TClientOptions>).Assembly.GetName().Version!.ToString());

    protected readonly TClientOptions _options;

    public GraphQLClient(TClientOptions options)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    public Task<GraphQLResponse<JsonElement>> ExecuteAsync(TGraphQLRequest request, CancellationToken cancellationToken = default)
    {
        //returing JsonElement and not JsonDocument because JsonDocument is disposable and we don't want to force the user to dispose it
        return ExecuteAsync<JsonElement>(request, cancellationToken);
    }

    public async Task<GraphQLResponse<T>> ExecuteAsync<T>(TGraphQLRequest request, CancellationToken cancellationToken = default)
    {
        var interceptor = _options.Interceptor ?? NoOpInterceptor.Instance;

        try
        {
            return await interceptor.InterceptRequestAsync(request, _options, cancellationToken, ExecuteCoreAsync<T>);
        }
        catch (Exception ex) when (ex is not GraphQLException)
        {
            throw new GraphQLInterceptorException(request, interceptor, ex);
        }
    }

    private async Task<GraphQLResponse<T>> ExecuteCoreAsync<T>(TGraphQLRequest request, CancellationToken cancellationToken = default)
    {
        HttpResponse httpResponse = null;
        try
        {
            using HttpRequestMessage requestMessage = CreateHttpRequest(request);
            var httpClient = _options.HttpClient ?? _defaultHttpClient;
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
                res = await httpResponseMsg.Content.ReadFromJsonAsync<GraphQLResponse<T>>(_options.JsonSerializerOptions ?? Serializer.Options, cancellationToken);
                if (res == null)
                    throw new GraphQLException(request, httpResponse, $"Failed to deserialize null GraphQL response. Request: {request}");
            }
            catch (Exception jsonEx)
            {
                throw new GraphQLException(request, httpResponse, $"Failed to deserialize GraphQL response. Request: {request}", jsonEx);
            }

            res.Request = request;
            res.HttpResponse = httpResponse;

            if (_options.ThrowOnGraphQLErrors ?? true)
                res.ThrowIfAnyError();

            return res;
        }
        catch (Exception ex) when (ex is not GraphQLException)
        {
            throw new GraphQLException(request, httpResponse, $"Unexpected GraphQL error: {request}", ex);
        }
    }

    private HttpRequestMessage CreateHttpRequest(TGraphQLRequest request)
    {
        _ = request.query ?? throw new ArgumentNullException(nameof(request.query));
        var uri = _options.Uri ?? throw new ArgumentNullException($"{nameof(IGraphQLClientOptions.Uri)} must a non-null URI.");
        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = uri,
            Content = JsonContent.Create(request, options: _options.JsonSerializerOptions ?? Serializer.Options),
        };

        requestMessage.Headers.UserAgent.Add(_defaultUserAgent);
        _options.ConfigureHttpRequestHeaders?.Invoke(requestMessage.Headers);
        return requestMessage;
    }
}