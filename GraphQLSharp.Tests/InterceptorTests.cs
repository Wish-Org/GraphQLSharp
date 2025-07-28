using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphQLSharp.Tests;

[TestClass]
public class InterceptorTests
{
    private GraphQLCLient _client = new();

    [TestInitialize]
    public void Initialize()
    {
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
        var options = new GraphQLClientOptions
        {
            Uri = new Uri("https://example.com/graphql"),
            Interceptor = new RetryInterceptor(),
            HttpClient = new HttpClient(new TestHttpMessageHandler(msg =>
            {
                var statusCode = ++tries <= RetryInterceptor.MAX_TRIES - 1 ? HttpStatusCode.InternalServerError : HttpStatusCode.OK;
                return new HttpResponseMessage(statusCode)
                {
                    Content = new StringContent("""{"data":{"shop":{"id":"gid://shopify/Shop/1234567890"}}}""")
                };
            }))
        };
        var response = await _client.ExecuteAsync(query, options);
        Assert.AreEqual(RetryInterceptor.MAX_TRIES, tries);
        Assert.AreEqual(HttpStatusCode.OK, response.HttpResponse.StatusCode);
    }

}