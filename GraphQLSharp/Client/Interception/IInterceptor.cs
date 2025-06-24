namespace GraphQLSharp;

public interface IInterceptor
{
    Task<GraphQLResponse<T>> InterceptRequestAsync<T>(GraphQLRequest request, Func<GraphQLRequest, Task<GraphQLResponse<T>>> executeAsync, CancellationToken cancellationToken);
}