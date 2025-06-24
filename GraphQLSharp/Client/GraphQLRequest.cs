using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace GraphQLSharp;

public class GraphQLRequest
{
    [StringSyntax("GraphQL")]
    public required string query { get; set; }

    public string operationName { get; set; }

    public IDictionary<string, object> variables { get; set; }

    public override string ToString()
    {
        return $"""
                query: {query},
                operationName: {operationName},
                variables: {JsonSerializer.Serialize(variables, new JsonSerializerOptions { WriteIndented = true })},
            """;
    }
}
