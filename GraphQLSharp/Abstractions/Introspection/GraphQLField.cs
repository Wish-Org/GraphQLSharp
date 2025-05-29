namespace GraphQLSharp;

public class GraphQLField
{
    public string name { get; set; }
    public string description { get; set; }
    public bool isDeprecated { get; set; }
    public string deprecationReason { get; set; }
    public GraphQLType type { get; set; }
}
