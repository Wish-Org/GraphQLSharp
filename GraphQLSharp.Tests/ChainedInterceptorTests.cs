using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphQLSharp.Tests;

[TestClass]
public class ChainedInterceptorTests
{
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
            Interceptor = new ChainedInterceptor(
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