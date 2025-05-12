using System.Text.Json.Serialization;

namespace GraphQLSharp;

public class GraphQLField
{
    public string name { get; set; }
    public string description { get; set; }
    public bool isDeprecated { get; set; }
    public string deprecationReason { get; set; }
    public GraphQLType type { get; set; }
}

public class GraphQLEnumValue
{
    public string name { get; set; }
    public string description { get; set; }
    public bool isDeprecated { get; set; }
    public string deprecationReason { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GraphQLTypeKind
{
    UNKNOWN,
    SCALAR,
    OBJECT,
    INTERFACE,
    UNION,
    ENUM,
    INPUT_OBJECT,
    LIST,
    NON_NULL
}

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

    //non-null for INTERFACE and UNION
    public GraphQLType[] possibleTypes { get; set; }
}
