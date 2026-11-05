using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphQLSharp.Tests;

[TestClass]
public class GraphQLHttpExceptionTests
{
    private const string Query = "{ shop { id } }";

    private static GraphQLCLient CreateClient(HttpStatusCode statusCode, string body, string mediaType)
    {
        return new GraphQLCLient(new GraphQLClientOptions(new Uri("https://example.com/graphql"))
        {
            HttpClient = new TestHttpClient(_ => new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(body, Encoding.UTF8, mediaType)
            })
        });
    }

    [TestMethod]
    public async Task GraphQLErrorResponseIsParsed()
    {
        var client = CreateClient(HttpStatusCode.BadRequest,
            """{"errors":[{"message":"Field 'foo' doesn't exist","locations":[{"line":1,"column":3}],"extensions":{"code":"GRAPHQL_VALIDATION_FAILED"}}]}""",
            "application/graphql-response+json");

        var ex = await Assert.ThrowsExceptionAsync<GraphQLHttpException>(() => client.ExecuteAsync(Query));

        Assert.AreEqual(HttpStatusCode.BadRequest, ex.HttpResponse.StatusCode);
        Assert.IsNotNull(ex.Response);
        Assert.AreEqual(1, ex.Response.errors.Count);
        Assert.AreEqual("Field 'foo' doesn't exist", ex.Response.errors[0].message);
        Assert.AreEqual("GRAPHQL_VALIDATION_FAILED", ex.Response.errors[0].extensions["code"].GetString());
        Assert.AreSame(ex.Request, ex.Response.Request);
        Assert.AreSame(ex.HttpResponse, ex.Response.HttpResponse);
        StringAssert.Contains(ex.Message, "Field 'foo' doesn't exist");
    }

    [TestMethod]
    public async Task NonGraphQLJsonErrorKeepsRawBody()
    {
        //e.g. Shopify returns a plain string in "errors" for authentication failures
        var body = """{"errors":"[API] Invalid API key or access token (unrecognized login or wrong password)"}""";
        var client = CreateClient(HttpStatusCode.Unauthorized, body, "application/json");

        var ex = await Assert.ThrowsExceptionAsync<GraphQLHttpException>(() => client.ExecuteAsync(Query));

        Assert.IsNull(ex.Response);
        Assert.AreEqual(body, ex.ResponseBody);
        StringAssert.Contains(ex.Message, "Invalid API key or access token");
    }

    [TestMethod]
    public async Task JsonWithoutGraphQLShapeIsNotParsed()
    {
        var body = """{"error":"Not found"}""";
        var client = CreateClient(HttpStatusCode.NotFound, body, "application/json");

        var ex = await Assert.ThrowsExceptionAsync<GraphQLHttpException>(() => client.ExecuteAsync(Query));

        Assert.IsNull(ex.Response);
        Assert.AreEqual(body, ex.ResponseBody);
    }

    [TestMethod]
    public async Task NonJsonBodyIsNotParsedAndTruncatedInMessage()
    {
        var body = $"<html><body>{new string('x', 5000)}</body></html>";
        var client = CreateClient(HttpStatusCode.BadGateway, body, "text/html");

        var ex = await Assert.ThrowsExceptionAsync<GraphQLHttpException>(() => client.ExecuteAsync(Query));

        Assert.IsNull(ex.Response);
        Assert.AreEqual(body, ex.ResponseBody);
        StringAssert.Contains(ex.Message, "(truncated)");
        Assert.IsTrue(ex.Message.Length < body.Length);
    }

    [TestMethod]
    public async Task EmptyBody()
    {
        var client = CreateClient(HttpStatusCode.ServiceUnavailable, "", "text/plain");

        var ex = await Assert.ThrowsExceptionAsync<GraphQLHttpException>(() => client.ExecuteAsync(Query));

        Assert.IsNull(ex.Response);
        Assert.IsNull(ex.ResponseBody);
    }

    [TestMethod]
    public async Task ErrorBodyStillRetried()
    {
        int tries = 0;
        var options = new GraphQLClientOptions(new Uri("https://example.com/graphql"))
        {
            Interceptor = new RetryInterceptor<GraphQLRequest, GraphQLClientOptions>(),
            HttpClient = new TestHttpClient(_ =>
            {
                tries++;
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
                {
                    Content = new StringContent("""{"errors":[{"message":"Service unavailable"}]}""", Encoding.UTF8, "application/json")
                };
            })
        };

        var ex = await Assert.ThrowsExceptionAsync<GraphQLHttpException>(() => new GraphQLCLient(options).ExecuteAsync(Query));

        Assert.AreEqual(RetryInterceptor<GraphQLRequest, GraphQLClientOptions>.MAX_TRIES, tries);
        Assert.AreEqual("Service unavailable", ex.Response.errors[0].message);
    }
}
