using GraphQLSharp;

public class TestInterceptor : IInterceptor
{
    private readonly Action _onBeforeExecute;
    private readonly Action _onAfterExecute;

    public TestInterceptor(Action onBeforeExecute, Action onAfterExecute)
    {
        _onBeforeExecute = onBeforeExecute;
        _onAfterExecute = onAfterExecute;
    }

    public async Task<GraphQLResponse<TData>> InterceptRequestAsync<TGraphQLRequest, TClientOptions, TData>(
        TGraphQLRequest request,
        TClientOptions defaultOptions,
        TClientOptions options,
        CancellationToken cancellationToken,
        Func<TGraphQLRequest, CancellationToken, Task<GraphQLResponse<TData>>> executeAsync)
        where TGraphQLRequest : GraphQLRequest, new()
        where TClientOptions : GraphQLClientOptions
    {
        _onBeforeExecute?.Invoke();
        var response = await executeAsync(request, cancellationToken);
        _onAfterExecute?.Invoke();
        return response;
    }
}
