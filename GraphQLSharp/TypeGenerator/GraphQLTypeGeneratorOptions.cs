namespace GraphQLSharp;

public class GraphQLTypeGeneratorOptions
{
    /// <summary>
    /// The namespace to use for the generated types.
    /// </summary>
    public string NamespaceTypes { get; set; }

    /// <summary>
    /// The namespace to use for the generated client.
    /// </summary>
    public string NamespaceClient { get; set; }

    /// <summary>
    /// A mapping of scalar GraphQL type names to .NET type names.
    /// </summary>
    public Dictionary<string, string> ScalarTypeNameToDotNetTypeName { get; set; }

    /// <summary>
    /// A mapping to override the default type of class members.
    /// </summary>
    public Dictionary<(string, string), string> GraphQLTypeToTypeNameOverride { get; set; }

    /// <summary>
    /// Indicates whether enum members are generated as enum or string.
    /// Defaults to false. 
    /// Enum types will still be generated regardless of this setting.
    /// </summary>
    public bool EnumMembersAsString { get; set; }

    /// <summary>
    /// An optional Type that represents the client options for the generated GraphQL client.
    /// The type must inherit from GraphQLClientOptionsBase and implement IGraphQLClientOptions.
    /// </summary>
    public Type ClientOptionsType { get; set; }

    /// <summary>
    /// An optional Type that represents the GraphQLRequest for the generated GraphQL client.
    /// The type must inherit from GraphQLRequest.
    /// </summary>
    public Type GraphQLRequestType { get; set; }

    /// <summary>
    /// Indicates whether to generate member names for the GraphQL types.
    /// Defaults to false
    /// If true, the member names will be generated based on the .NET type names.
    /// </summary>
    public bool GenerateMemberNames { get; set; }
}