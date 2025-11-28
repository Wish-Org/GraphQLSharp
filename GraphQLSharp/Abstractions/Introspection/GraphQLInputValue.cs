namespace GraphQLSharp;

public class GraphQLInputValue
{
    public string name { get; set; }
    public string description { get; set; }
    public GraphQLType type { get; set; }
    public string defaultValue { get; set; }
    public bool isDeprecated { get; set; }
    public string deprecationReason { get; set; }
}
