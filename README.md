[![Build](https://github.com/Wish-Org/GraphQLSharp/actions/workflows/ci.yml/badge.svg)](https://github.com/Wish-Org/GraphQLSharp/actions)
[![NuGet](https://img.shields.io/nuget/v/GraphQLSharp.svg)](https://www.nuget.org/packages/GraphQLSharp)

Use `GraphQLTypeGenerator` to generate .NET types from a GraphQL endpoint.

Example:

```csharp

async Task<JsonDocument> SendGraphQLQueryAsync(string graphqlQuery)
{
  //Call your GraphQL endpoint and return the result of the introspection query
}
var generator = new GraphQLTypeGenerator();
var options = new GraphQLTypeGeneratorOptions
{
    Namespace = "MyNamespace",
    ScalarNameTypeToTypeName = new Dictionary<string, string>
        {
            { "UnsignedInt64", "ulong" },
            { "Money", "decimal" }
        },
    EnumMembersAsString = true
};
var csharpCode = generator.GenerateTypesAsync(options, async introspectionQuery => await GetResponse(introspectionQuery));
File.WriteAllText("types.cs", csharpCode);
```
   
