[![Build](https://github.com/Wish-Org/GraphQLSharp/actions/workflows/ci.yml/badge.svg)](https://github.com/Wish-Org/GraphQLSharp/actions)
[![NuGet](https://img.shields.io/nuget/v/GraphQLSharp.svg)](https://www.nuget.org/packages/GraphQLSharp)

`GraphQLSharp` is a modern .NET library to work with GraphQL.

# `GraphClient` - A modern and performant GraphQL client

Examples:

```csharp

private GraphQLClient _client;

[TestInitialize]
public void Initialize()
{
    _client = new GraphQLClient(new GraphQLRequestOptions
    {
        Uri = new Uri($"https://example.com/graphql.json"),
        ThrowOnGraphQLErrors = true,
        //HttpClient = myHttpClient, optionally provide your own HttpClient instance
        //Interceptor = myInterceptor, optionally provide an interceptor for logging, automatic retires, etc...
        ConfigureHttpRequestHeaders = headers =>
        {
            headers.Add("X-Access-Token", "<INSERT_TOKEN>");
        },
    });
}

[TestMethod]
public async Task RequestSimple()
{
    var query = """
        query {
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

    //response is strongly typed
    var response = await _client.ExecuteAsync<QueryRoot>(query);
    Assert.IsNotNull(response.data.products.nodes.FirstOrDefault()?.id);
}


[TestMethod]
public async Task RequestSimpleWithVariables()
{
    var query = """
        query ($first: Int!){
            products(first: $first)
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
        variables = new Dictionary<string, object>
        {
            { "first", 10 }
        }
    };

    //response is strongly typed
    var response = await _client.ExecuteAsync<QueryRoot>(request);
    Assert.IsNotNull(response.data.products.nodes.FirstOrDefault()?.id);
}

[TestMethod]
public async Task RequestWithMultipleOperations()
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
    Assert.IsNotNull(response.data.products.nodes.FirstOrDefault()?.id);
}

[TestMethod]
public async Task RequestWithAliases()
{
    var query = """
        query ($first: Int!) {
            myProducts: products(first: $first)
            {
                nodes
                {
                    id
                    title
                }
            }
            myOrders: orders(first: $first)
            {
                nodes
                {
                    id
                    name
                }
            }
        }
        """;

    var request = new GraphQLRequest
    {
        query = query,
        variables = new Dictionary<string, object>
        {
            { "first", 10 }
        }
    };

    var response = await _client.ExecuteAsync(request);
    //response.data is JsonElement
    var myProducts = response.data.GetProperty("myProducts")
                                    .Deserialize<ProductConnection>(Serializer.Options);
    var myOrders = response.data.GetProperty("myOrders")
                                    .Deserialize<OrderConnection>(Serializer.Options);
    Assert.IsNotNull(myProducts.nodes.FirstOrDefault()?.title);
    Assert.IsNotNull(myOrders.nodes.FirstOrDefault()?.name);
}
```

Note: `GraphClient` is thread-safe and can be used as a long lived shared instance.

# `GraphQLTypeGenerator` - Generate .NET types from any GraphQL endpoint

```csharp
async Task<JsonDocument> SendGraphQLQueryAsync(string graphqlQuery)
{
  //Call your GraphQL endpoint and return the result of the given introspection query
}
var generator = new GraphQLTypeGenerator();
var options = new GraphQLTypeGeneratorOptions
{
    Namespace = "MyNamespace",
    ScalarTypeNameToDotNetTypeName = new Dictionary<string, string>
        {
            { "UnsignedInt64", "ulong" },
            { "Money", "decimal" }
        },
    EnumMembersAsString = true
};
var csharpCode = generator.GenerateTypesAsync(options, async introspectionQuery => await SendGraphQLQueryAsync(introspectionQuery));
File.WriteAllText("types.cs", csharpCode);
```
