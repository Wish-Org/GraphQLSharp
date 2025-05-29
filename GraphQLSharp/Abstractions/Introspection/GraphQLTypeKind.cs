using System.Text.Json.Serialization;

namespace GraphQLSharp;

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
