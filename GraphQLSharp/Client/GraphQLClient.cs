using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace GraphQLSharp;

public class GraphQLClient<TGraphQLRequest, TClientOptions, TQueryRoot, TMutationRoot> : GraphQLClient<TGraphQLRequest, TClientOptions, TQueryRoot>
    where TGraphQLRequest : GraphQLRequest, new()
    where TQueryRoot : class
    where TMutationRoot : class
    where TClientOptions : GraphQLClientOptionsBase, IGraphQLClientOptions
{
    public GraphQLClient(TClientOptions defaultOptions = null) : base(defaultOptions)
    {
    }

    public Task<GraphQLResponse<TMutationRoot>> MutationAsync(TGraphQLRequest request, TClientOptions options = null, CancellationToken cancellationToken = default)
    {
        return ExecuteAsync<TMutationRoot>(request, options, cancellationToken);
    }
}

public class GraphQLClient<TGraphQLRequest, TClientOptions, TQueryRoot> : GraphQLClient<TGraphQLRequest, TClientOptions>
    where TGraphQLRequest : GraphQLRequest, new()
    where TQueryRoot : class
    where TClientOptions : GraphQLClientOptionsBase, IGraphQLClientOptions
{
    public GraphQLClient(TClientOptions defaultOptions = null) : base(defaultOptions)
    {
    }

    public Task<GraphQLResponse<TQueryRoot>> QueryAsync(TGraphQLRequest request, TClientOptions options = null, CancellationToken cancellationToken = default)
    {
        return ExecuteAsync<TQueryRoot>(request, options, cancellationToken);
    }
}

public class GraphQLCLient : GraphQLClient<GraphQLRequest, GraphQLClientOptions>
{
    public GraphQLCLient(GraphQLClientOptions defaultOptions = null) : base(defaultOptions)
    {
    }
}

public class GraphQLClient<TGraphQLRequest, TClientOptions>
    where TGraphQLRequest : GraphQLRequest, new()
    where TClientOptions : GraphQLClientOptionsBase, IGraphQLClientOptions
{
    private static readonly HttpClient _defaultHttpClient = new();

    private static readonly ProductInfoHeaderValue _defaultUserAgent = new(typeof(GraphQLClient<TGraphQLRequest, TClientOptions>).Assembly.GetName().Name!, typeof(GraphQLClient<TGraphQLRequest, TClientOptions>).Assembly.GetName().Version!.ToString());

    protected readonly TClientOptions _defaultOptions;

    public GraphQLClient(TClientOptions defaultOptions = null)
    {
        _defaultOptions = defaultOptions;
    }

    protected virtual IInterceptor DefaultInterceptor => NoOpInterceptor.Instance;

    protected T GetOptionValue<T>(TClientOptions requestOptions, Func<TClientOptions, T> optionSelector, T defaultValue = default)
    {
        var requestOptionValue = requestOptions == null ? default : optionSelector(requestOptions);
        var defaultOptionValue = _defaultOptions == null ? default : optionSelector(_defaultOptions);
        return requestOptionValue ?? defaultOptionValue ?? defaultValue;
    }

    protected IInterceptor GetInterceptor(TClientOptions requestOptions)
            => GetOptionValue(requestOptions, o => o.Interceptor, DefaultInterceptor ?? NoOpInterceptor.Instance);

    protected JsonSerializerOptions GetJsonSerializerOptions(TClientOptions requestOptions)
            => GetOptionValue(requestOptions, o => o.JsonSerializerOptions, Serializer.Options);

    protected HttpClient GetHttpClient(TClientOptions requestOptions)
            => GetOptionValue(requestOptions, o => o.HttpClient, _defaultHttpClient);

    protected bool GetThrowOnGraphQLErrors(TClientOptions requestOptions)
            => GetOptionValue(requestOptions, o => o.ThrowOnGraphQLErrors, true).Value;

    protected Uri GetUri(TClientOptions requestOptions)
            => GetOptionValue(requestOptions, o => o.Uri, null);

    protected Action<HttpRequestHeaders> GetConfigureHttpRequestHeaders(TClientOptions requestOptions)
            => GetOptionValue(requestOptions, o => o.ConfigureHttpRequestHeaders, null);


    public Task<GraphQLResponse<JsonElement>> ExecuteAsync(TGraphQLRequest request, TClientOptions options = null, CancellationToken cancellationToken = default)
    {
        //returing JsonElement and not JsonDocument because JsonDocument is disposable and we don't want to force the user to dispose it
        return ExecuteAsync<JsonElement>(request, options, cancellationToken);
    }

    public async Task<GraphQLResponse<T>> ExecuteAsync<T>(TGraphQLRequest request, TClientOptions options = null, CancellationToken cancellationToken = default)
    {
        var interceptor = GetInterceptor(options);

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

    private async Task<GraphQLResponse<T>> ExecuteCoreAsync<T>(TGraphQLRequest request, TClientOptions options = null, CancellationToken cancellationToken = default)
    {
        HttpResponse httpResponse = null;
        try
        {
            using HttpRequestMessage requestMessage = CreateHttpRequest(request, options);
            var httpClient = GetOptionValue(options, o => o.HttpClient, _defaultHttpClient);
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
                res = await httpResponseMsg.Content.ReadFromJsonAsync<GraphQLResponse<T>>(GetJsonSerializerOptions(options), cancellationToken);
                if (res == null)
                    throw new GraphQLException(request, httpResponse, $"Failed to deserialize null GraphQL response. Request: {request}");
            }
            catch (Exception jsonEx)
            {
                throw new GraphQLException(request, httpResponse, $"Failed to deserialize GraphQL response. Request: {request}", jsonEx);
            }

            res.Request = request;
            res.HttpResponse = httpResponse;

            bool throwOnGraphQLErrors = GetThrowOnGraphQLErrors(options);
            if (throwOnGraphQLErrors)
                res.ThrowIfAnyError();

            return res;
        }
        catch (Exception ex) when (ex is not GraphQLException)
        {
            throw new GraphQLException(request, httpResponse, $"Unexpected GraphQL error: {request}", ex);
        }
    }

    private HttpRequestMessage CreateHttpRequest(TGraphQLRequest request, TClientOptions options)
    {
        _ = request.query ?? throw new ArgumentNullException(nameof(request.query));
        var uri = GetUri(options) ?? throw new ArgumentNullException(nameof(IGraphQLClientOptions.Uri));
        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = uri,
            Content = JsonContent.Create(request, options: GetJsonSerializerOptions(options)),
        };

        requestMessage.Headers.UserAgent.Add(_defaultUserAgent);
        GetConfigureHttpRequestHeaders(options)?.Invoke(requestMessage.Headers);
        return requestMessage;
    }
}