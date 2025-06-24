namespace GraphQLSharp;

public interface IInterceptor
{
    Task<GraphQLResponse<T>> InterceptRequestAsync<T>(GraphQLRequest request,
                                                      GraphQLRequestOptions options,
                                                      Func<GraphQLRequest, GraphQLRequestOptions, Task<GraphQLResponse<T>>> executeAsync,
                                                      CancellationToken cancellationToken);
}