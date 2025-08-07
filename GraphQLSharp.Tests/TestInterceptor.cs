using GraphQLSharp;

public class TestInterceptor : IInterceptor<GraphQLRequest, GraphQLClientOptions>
{
    private readonly Action _onBeforeExecute;
    private readonly Action _onAfterExecute;

    public TestInterceptor(Action onBeforeExecute, Action onAfterExecute)
    {
        _onBeforeExecute = onBeforeExecute;
        _onAfterExecute = onAfterExecute;
    }

    public async Task<GraphQLResponse<TData>> InterceptRequestAsync<TData>(GraphQLRequest request, GraphQLClientOptions options, CancellationToken cancellationToken, Func<GraphQLRequest, CancellationToken, Task<GraphQLResponse<TData>>> executeAsync)
    {
        _onBeforeExecute?.Invoke();
        var response = await executeAsync(request, cancellationToken);
        _onAfterExecute?.Invoke();
        return response;
    }
}
