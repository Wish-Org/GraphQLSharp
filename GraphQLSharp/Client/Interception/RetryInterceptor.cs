using System.Net;

namespace GraphQLSharp;

public class RetryInterceptor<TRequest, TOptions> : IInterceptor<TRequest, TOptions>
    where TRequest : GraphQLRequest
    where TOptions : class, IGraphQLClientOptions<TOptions, TRequest>
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

    public async Task<GraphQLResponse<TData>> InterceptRequestAsync<TData>(TRequest request, TOptions options, CancellationToken cancellationToken, Func<TRequest, CancellationToken, Task<GraphQLResponse<TData>>> executeAsync)
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
