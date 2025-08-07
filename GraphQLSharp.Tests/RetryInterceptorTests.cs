using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphQLSharp.Tests;

[TestClass]
public class RetryInterceptorTests
{
    [TestMethod]
    public async Task NoRetryOnSuccess()
    {
        var query = """
            {
                shop
                {
                    id
                }
            }
            """;

        int tries = 0;
        var options = new GraphQLClientOptions(new Uri("https://example.com/graphql"))
        {
            Interceptor = new RetryInterceptor<GraphQLRequest, GraphQLClientOptions>(),
            HttpClient = new TestHttpClient(msg =>
            {
                ++tries;
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("""{"data":{"shop":{"id":"gid://shopify/Shop/1234567890"}}}""")
                };
            })
        };
        var response = await new GraphQLCLient(options).ExecuteAsync(query);
        Assert.AreEqual(1, tries);
        Assert.AreEqual(HttpStatusCode.OK, response.HttpResponse.StatusCode);
    }

    [TestMethod]
    public async Task RetryOnServerError()
    {
        var query = """
            {
                shop
                {
                    id
                }
            }
            """;

        int tries = 0;
        var options = new GraphQLClientOptions(new Uri("https://example.com/graphql"))
        {
            Interceptor = new RetryInterceptor<GraphQLRequest, GraphQLClientOptions>(),
            HttpClient = new TestHttpClient(msg =>
            {
                var statusCode = ++tries <= RetryInterceptor<GraphQLRequest, GraphQLClientOptions>.MAX_TRIES - 1 ? HttpStatusCode.InternalServerError : HttpStatusCode.OK;
                return new HttpResponseMessage(statusCode)
                {
                    Content = new StringContent("""{"data":{"shop":{"id":"gid://shopify/Shop/1234567890"}}}""")
                };
            })
        };
        var response = await new GraphQLCLient(options).ExecuteAsync(query);
        Assert.AreEqual(RetryInterceptor<GraphQLRequest, GraphQLClientOptions>.MAX_TRIES, tries);
        Assert.AreEqual(HttpStatusCode.OK, response.HttpResponse.StatusCode);
    }
}