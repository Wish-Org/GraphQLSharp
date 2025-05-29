namespace GraphQLSharp;

public class GraphQLEnumValue
{
    public string name { get; set; }
    public string description { get; set; }
    public bool isDeprecated { get; set; }
    public string deprecationReason { get; set; }
}
