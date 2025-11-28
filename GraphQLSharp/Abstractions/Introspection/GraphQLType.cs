using System.Text.Json.Serialization;

namespace GraphQLSharp;

public class GraphQLType
{
    public string name { get; set; }

    public string description { get; set; }

    public GraphQLTypeKind kind { get; set; }

    //non-null for NON_NULL and LIST
    public GraphQLType ofType { get; set; }

    //non-null for ENUM
    public GraphQLEnumValue[] enumValues { get; set; }

    //non-null for OBJECT and INTERFACE
    public GraphQLField[] fields { get; set; }

    //non-null for OBJECT and INTERFACE
    public GraphQLType[] interfaces { get; set; }

    //non-null for INPUT_OBJECT
    public GraphQLField[] inputFields { get; set; }

    //non-null for INTERFACE and UNION
    public GraphQLType[] possibleTypes { get; set; }
}
