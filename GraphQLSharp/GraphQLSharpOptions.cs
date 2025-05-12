using System.Collections.Generic;

namespace GraphQLSharp;

public class GraphQLSharpOptions
{
    /// <summary>
    /// The namespace to use for the generated types.
    /// </summary>
    public string Namespace { get; set; }

    /// <summary>
    /// A mapping of scalar GraphQL type names to .NET type names.
    /// </summary>
    public Dictionary<string, string> ScalarNameTypeToTypeName { get; set; }

    /// <summary>
    /// A mapping to override the default type of class members.
    /// </summary>
    public Dictionary<(string, string), string> GraphQLTypeToTypeNameOverride { get; set; }

    /// <summary>
    /// Indicates whether enum members are generated as enum or string. Enum types will still be generated regardless of this setting.
    /// </summary>
    public bool EnumMembersAsString { get; set; }
}