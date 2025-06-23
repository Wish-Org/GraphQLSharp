namespace GraphQLSharp;

public class GraphQLRequest
{
    public required string query { get; set; }

    public string operationName { get; set; }

    public IDictionary<string, object> variables { get; set; }
}
