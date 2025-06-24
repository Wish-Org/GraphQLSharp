using Microsoft.VisualStudio.TestTools.UnitTesting;
using shopify;

namespace GraphQLSharp.Tests;

[TestClass]
public class GraphQLClientTests
{
    private GraphQLClient _client;

    [TestInitialize]
    public void Initialize()
    {
        string shopId = Environment.GetEnvironmentVariable("GRAPHQLSHARP_SHOP_ID", EnvironmentVariableTarget.User);
        string token = Environment.GetEnvironmentVariable("GRAPHQLSHARP_SHOP_TOKEN", EnvironmentVariableTarget.User);

        _client = new GraphQLClient(new GraphQLRequestOptions
        {
            Uri = new Uri($"https://{shopId}/admin/api/2025-04/graphql.json"),
            ConfigureHttpRequestHeaders = headers =>
            {
                headers.UserAgent.Add(new(typeof(GraphQLClientTests).Assembly.GetName().Name!, typeof(GraphQLClientTests).Assembly.GetName().Version!.ToString()));
                headers.Add("X-Shopify-Access-Token", token);
            }
        });
    }

    [TestMethod]
    public async Task RequestAsync_BasicQuery_ReturnsValidResponse()
    {
        var query = """
            query myQuery($first: Int!) {
                products(first: $first)
                {
                    nodes
                    {
                        id
                        title
                    }
                }
            }
            query myQuery2 {
                products(first: 10)
                {
                    nodes
                    {
                        id
                        title
                    }
                }
            }
            """;

        var request = new GraphQLRequest
        {
            query = query,
            operationName = "myQuery",
            variables = new Dictionary<string, object>
            {
                { "first", 10 }
            }
        };

        var response = await _client.ExecuteAsync<QueryRoot>(request);
        Assert.IsNotNull(response.data.products.nodes.FirstOrDefault().id);
    }

    [TestMethod]
    [ExpectedException(typeof(GraphQLErrorsException))]
    public async Task RequestAsync_BasicQuery_ReturnsError()
    {
        var query = """
            query {
                products(first: 10)
                {
                    nodes
                    SYNTAX ERROR!!!
                        id
                        title
                    }
                }
            }
            """;

        var request = new GraphQLRequest
        {
            query = query
        };

        var response = await _client.ExecuteAsync<QueryRoot>(request);
    }

    [TestMethod]
    public async Task RequestAsync_BasicQuery_ReturnsErrorResponse()
    {
        var query = """
            query {
                products(first: 10)
                {
                    nodes
                    SYNTAX ERROR!!!
                        id
                        title
                    }
                }
            }
            """;

        var request = new GraphQLRequest
        {
            query = query
        };

        var response = await _client.ExecuteAsync<QueryRoot>(request,
                                            new GraphQLRequestOptions
                                            {
                                                ThrowOnGraphQLErrors = false
                                            });
        Assert.IsNotNull(response.errors);
        Assert.IsTrue(response.errors.Count > 0);
    }
}