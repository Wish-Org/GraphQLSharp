using System.Net;

namespace GraphQLSharp;

public class RetryInterceptor : IInterceptor
{
    private static readonly TimeSpan DEFAULT_RETRY_DELAY = TimeSpan.FromSeconds(1);
    public const int MAX_TRIES = 3;

    public static readonly HttpStatusCode[] _retryableStatusCodes =
    [
        HttpStatusCode.RequestTimeout,
        HttpStatusCode.TooManyRequests,
        HttpStatusCode.InternalServerError,
        HttpStatusCode.BadGateway,
        HttpStatusCode.ServiceUnavailable,
        HttpStatusCode.GatewayTimeout
    ];

    protected virtual bool ShouldRetry(HttpResponse r)
    {
        return _retryableStatusCodes.Contains(r.StatusCode);
    }

    public async Task<GraphQLResponse<TData>> InterceptRequestAsync<TGraphQLRequest, TClientOptions, TData>(
        TGraphQLRequest request,
        TClientOptions defaultOptions,
        TClientOptions requestOptions,
        CancellationToken cancellationToken,
        Func<TGraphQLRequest, CancellationToken, Task<GraphQLResponse<TData>>> executeAsync)
        where TGraphQLRequest : GraphQLRequest, new()
        where TClientOptions : GraphQLClientOptionsBase, IGraphQLClientOptions<TClientOptions>
    {
        int tryCount = 0;

        while (true)
        {
            try
            {
                return await executeAsync(request, cancellationToken);
            }
            catch (GraphQLHttpException ex) when (ShouldRetry(ex.HttpResponse) && ++tryCount < MAX_TRIES)
            {
                await Task.Delay(DEFAULT_RETRY_DELAY, cancellationToken);
            }
        }
    }
}
