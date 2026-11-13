using System.Net;
using System.Net.Http.Headers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphQLSharp.Tests;

[TestClass]
public class ChainedInterceptorTests
{
    [DataTestMethod]
    [DataRow(false)]
    [DataRow(true)]
    public async Task PreserveHeaderCallbacksOnEveryAttempt(bool retry)
    {
        var attempts = new List<string[]>();
        var options = new GraphQLClientOptions(new Uri("https://example.com/graphql"))
        {
            ConfigureHttpRequestHeaders = headers => headers.Add("X-Order", "options"),
            Interceptor = new ChainedInterceptor<GraphQLRequest, GraphQLClientOptions>(
                new HeaderInterceptor(headers => headers.Add("X-Order", "inner")),
                new HeaderInterceptor(headers => headers.Add("X-Order", "middle")),
                new RetryInterceptor<GraphQLRequest, GraphQLClientOptions>(),
                new HeaderInterceptor(headers => headers.Add("X-Order", "outer"))),
            HttpClient = new TestHttpClient(msg =>
            {
                attempts.Add(msg.Headers.GetValues("X-Order").ToArray());
                return new HttpResponseMessage(retry && attempts.Count == 1
                    ? HttpStatusCode.ServiceUnavailable : HttpStatusCode.OK)
                {
                    Content = new StringContent("""{"data":{}}""")
                };
            })
        };

        await new GraphQLCLient(options).ExecuteAsync("{ shop { id } }");

        Assert.AreEqual(retry ? 2 : 1, attempts.Count);
        foreach (var headers in attempts)
            CollectionAssert.AreEqual(new[] { "options", "outer", "middle", "inner" }, headers);
    }

    private sealed class HeaderInterceptor(Action<HttpRequestHeaders> configureHeaders)
        : IInterceptor<GraphQLRequest, GraphQLClientOptions>
    {
        public Task<GraphQLResponse<TData>> InterceptRequestAsync<TData>(GraphQLRequest request,
            GraphQLClientOptions options, CancellationToken cancellationToken,
            ExecuteRequestAsync<GraphQLRequest, TData> executeAsync)
        {
            return executeAsync(request, configureHeaders, cancellationToken);
        }
    }

    [TestMethod]
    public async Task CallInterceptorsInCorrectOrder()
    {
        var query = """
            {
                shop
                {
                    id
                }
            }
            """;

        var entries = new List<string>();
        var options = new GraphQLClientOptions(new Uri("https://example.com/graphql"))
        {
            Interceptor = new ChainedInterceptor<GraphQLRequest, GraphQLClientOptions>(
                new TestInterceptor(() => entries.Add("Before1"), () => entries.Add("After1")),
                new TestInterceptor(() => entries.Add("Before2"), () => entries.Add("After2")),
                new TestInterceptor(() => entries.Add("Before3"), () => entries.Add("After3"))
            ),
            HttpClient = new TestHttpClient(msg =>
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("""{"data":{"shop":{"id":"gid://shopify/Shop/1234567890"}}}""")
                };
            })
        };
        var response = await new GraphQLCLient(options).ExecuteAsync(query);
        Assert.AreEqual(HttpStatusCode.OK, response.HttpResponse.StatusCode);
        Assert.IsTrue(entries.SequenceEqual(
        [
            "Before3", "Before2", "Before1",
            "After1", "After2", "After3"
        ]));
    }
}
