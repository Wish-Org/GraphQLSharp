using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Security;
using System.Text;
using System.Text.Json;

namespace GraphQLSharp;

public class GraphQLTypeGenerator
{
    //we go quite deep because ofType is used for non-nullable and list
    //example: orders: [[String!]!]! would require 5 levels deep
    public const string INTROSPECTION_QUERY = """
            fragment fragType on __Type {
              name
              kind
              ofType {
                name
                kind
                ofType {
                  name
                  kind
                  ofType {
                    name
                    kind
                    ofType {
                      name
                      kind
                      ofType {
                        name
                        kind
                      }
                    }
                  }
                }
              }
            }

            fragment fragField on __Field {
              name
              description
              isDeprecated
              deprecationReason
              type {
                ...fragType
              }
            }

            {
              __schema {
                queryType
                {
                    name
                }
                mutationType
                {
                    name
                }
                types {
                  kind
                  name
                  description
                  fields(includeDeprecated: true) {
                    ...fragField
                  }
                  interfaces {
                    ...fragType
                    fields(includeDeprecated: true) {
                      ...fragField
                    }
                  }
                  possibleTypes {
                    ...fragType
                    fields(includeDeprecated: true) {
                      ...fragField
                    }
                    interfaces {
                      ...fragType
                    }
                  }
                  enumValues(includeDeprecated: true) {
                    name
                    description
                    isDeprecated
                    deprecationReason
                  }
                  ofType {
                    ...fragType
                  }
                }
              }
            }
            """;

    private static readonly Dictionary<string, string> _builtInScalarNameToTypeName = new()
            {
                { "String", "string" },
                { "Int", "int" },
                { "Float", "double" },
                { "Boolean", "bool" },
                { "ID", "string" },
                { "Scalar", "object" },
            };


    public async Task<string> GenerateTypesAsync(GraphQLTypeGeneratorOptions options, Func<string, Task<JsonDocument>> executeQuery)
    {
        var response = await executeQuery(INTROSPECTION_QUERY);
        return GenerateTypes(options, response);
    }

    private class Context
    {
        public readonly StringBuilder StrBuilder = new();
    }

    public string GenerateTypes(GraphQLTypeGeneratorOptions options, JsonDocument introspectionQueryResponse)
    {
        _ = options ?? throw new ArgumentNullException(nameof(options));
        _ = introspectionQueryResponse ?? throw new ArgumentNullException(nameof(introspectionQueryResponse));
        _ = options.NamespaceTypes ?? throw new ArgumentNullException(nameof(options.NamespaceTypes));
        _ = options.NamespaceClient ?? throw new ArgumentNullException(nameof(options.NamespaceClient));

        if (options.GraphQLRequestType != null && !typeof(GraphQLRequest).IsAssignableFrom(options.GraphQLRequestType))
            throw new ArgumentException($"{nameof(options.GraphQLRequestType)} must inherit from {nameof(GraphQLRequest)}", nameof(options.GraphQLRequestType));

        if (options.ClientOptionsType != null && !typeof(IGraphQLClientOptions<,>).MakeGenericType(options.ClientOptionsType, options.GraphQLRequestType).IsAssignableFrom(options.ClientOptionsType))
            throw new ArgumentException($"{nameof(options.ClientOptionsType)} must implement IGraphQLClientOptions<{options.ClientOptionsType.Name},{options.GraphQLRequestType.Name}>", nameof(options.ClientOptionsType));


        // Get the "data.__schema" element or "__schema" element if the "data" property doesn't exist
        var schemaElt = introspectionQueryResponse.RootElement.TryGetProperty("data", out var dataElt) ?
                        dataElt.GetProperty("__schema") :
                        introspectionQueryResponse.RootElement.GetProperty("__schema");

        var allTypes = schemaElt.GetProperty("types").Deserialize<GraphQLType[]>();
        var queryType = schemaElt.GetProperty("queryType").GetProperty("name").GetString();
        var mutationType = schemaElt.TryGetProperty("mutationType", out var elt) && elt.ValueKind == JsonValueKind.Object ? elt.GetProperty("name").GetString() : null;

        var clientOptionsTypeName = options.ClientOptionsType == null ? typeof(GraphQLClientOptions).Name : options.ClientOptionsType.FullName;
        var graphQLRequestTypeName = options.GraphQLRequestType == null ? typeof(GraphQLRequest).Name : options.GraphQLRequestType.FullName;
        string clientClassName = options.ClientClassName ?? "GraphQLClient";

        var context = new Context();
        var str = context.StrBuilder;
        str.AppendLine("using System;")
                .AppendLine("using System.Collections;")
                .AppendLine("using System.Collections.Generic;")
                .AppendLine("using System.ComponentModel;")
                .AppendLine("using System.Linq;")
                .AppendLine("using System.Text.Json;")
                .AppendLine("using System.Text.Json.Serialization;")
                .AppendLine("using GraphQLSharp;")
                .AppendLine($"namespace {options.NamespaceClient} {{")
                //generating partial class to allow for extension methods and member overrides
                .AppendLine($"public partial class {clientClassName} : ")
                .AppendLine(mutationType == null ? $"GraphQLClient<{graphQLRequestTypeName}, {clientOptionsTypeName}, {options.NamespaceTypes}.{queryType}>" : $"GraphQLClient<{graphQLRequestTypeName}, {clientOptionsTypeName}, {options.NamespaceTypes}.{queryType}, {options.NamespaceTypes}.{mutationType}>")
                .AppendLine($$"""
                    {
                        public {{clientClassName}}({{clientOptionsTypeName}}? options = null) : base(options!)
                        {
                        }
                    }
                    """)
                .AppendLine("}")
                .AppendLine($"namespace {options.NamespaceTypes} {{");

        var objectTypeNameToUnionTypes = allTypes.Where(t => t.kind == GraphQLTypeKind.UNION)
                                                  .SelectMany(tUnion => tUnion.possibleTypes.Select(tObject => (tUnion, tObject)))
                                                  .ToLookup(i => i.tObject.name, i => i.tUnion);

        var typeNameToType = allTypes.ToDictionary(t => t.name);

        allTypes.ForEach(t =>
        {
            GenerateType(context, t, typeNameToType, options, objectTypeNameToUnionTypes, (queryType, mutationType));
            str.AppendLine();
        });

        str.AppendLine("}");

        string code = str.ToString();
        var tree = CSharpSyntaxTree.ParseText(code);
        var root = (CSharpSyntaxNode)tree.GetRoot();
        string formattedCode = root.NormalizeWhitespace().ToString();
        return $"""
            // <auto-generated/>
            #nullable enable
            {formattedCode}
            """;
    }

    private void GenerateType(Context ctx, GraphQLType type, Dictionary<string, GraphQLType> typeNameToType, GraphQLTypeGeneratorOptions options, ILookup<string, GraphQLType> objectTypeNameToUnionTypes, (string queryType, string mutationType) rootTypes)
    {
        if (type.kind is GraphQLTypeKind.SCALAR or GraphQLTypeKind.INPUT_OBJECT)
            return;
        else if (type.kind is GraphQLTypeKind.ENUM)
            GenerateEnum(ctx, type);
        else if (type.kind is GraphQLTypeKind.OBJECT)
            GenerateClass(ctx, type, typeNameToType, options, objectTypeNameToUnionTypes, rootTypes);
        else if (type.kind is GraphQLTypeKind.INTERFACE)
            GenerateInterface(ctx, type, typeNameToType, options);
        else if (type.kind is GraphQLTypeKind.UNION)
            GenerateUnion(ctx, type, typeNameToType, options);
        else
            throw new Exception($"Unexpected type kind {type.kind}");
    }

    private void GenerateUnion(Context ctx, GraphQLType type, Dictionary<string, GraphQLType> typeNameToType, GraphQLTypeGeneratorOptions options)
    {
        var str = ctx.StrBuilder
                        .AppendLine(GenerateDescriptionCommentAndAttribute(type.description))
                        .AppendLine("[JsonPolymorphic(TypeDiscriminatorPropertyName = \"__typename\")]");

        var possibleTypes = type.possibleTypes
                                .Where(t => typeNameToType.ContainsKey(t.name))
                                .DistinctBy(t => t.name);//found cases where possibleTypes included types that don't exist, so remove them
        foreach (var t in possibleTypes)
        {
            str.AppendLine($"[JsonDerivedType(typeof({GenerateTypeName(t, options)}), typeDiscriminator: \"{t.name}\")]");
        }


        string interfaceName = GenerateTypeName(type, options);
        str.AppendLine($"public interface {interfaceName} : {nameof(IGraphQLObject)}");

        str.AppendLine("{");

        foreach (var t in possibleTypes)
        {
            var typeName = GenerateTypeName(t, options);
            str.AppendLine($"public {typeName}? As{typeName}() => this as {typeName};");
        }

        var commonFields = possibleTypes.First().fields.AsEnumerable();
        foreach (var t in possibleTypes.Skip(1))
        {
            commonFields = commonFields.IntersectBy(t.fields.Select(f => (GenerateTypeName(f.type, options), f.name)),
                                                    f => (GenerateTypeName(f.type, options), f.name));
        }

        commonFields
            .ForEach(f => GenerateField(ctx, type, f, options));

        str.AppendLine("}");
    }

    private void GenerateInterface(Context ctx, GraphQLType type, Dictionary<string, GraphQLType> typeNameToType, GraphQLTypeGeneratorOptions options)
    {
        var str = ctx.StrBuilder
                        .AppendLine(GenerateDescriptionCommentAndAttribute(type.description))
                        .AppendLine("[JsonPolymorphic(TypeDiscriminatorPropertyName = \"__typename\")]");

        var possibleTypes = type.possibleTypes
                                .Where(t => typeNameToType.ContainsKey(t.name))
                                .DistinctBy(t => t.name);//found cases where possibleTypes included types that don't exist, so remove them
        foreach (var t in possibleTypes)
        {
            str.AppendLine($"[JsonDerivedType(typeof({GenerateTypeName(t, options)}), typeDiscriminator: \"{t.name}\")]");
        }

        string interfaceName = GenerateTypeName(type, options);
        str.AppendLine($"public interface {interfaceName} : {nameof(IGraphQLObject)}");

        var interfaces = type.interfaces;
        if (interfaces?.Any() == true)
            str.Append($", {string.Join(',', interfaces.Select(i => this.GenerateTypeName(i, options)))}");
        str.AppendLine();
        str.AppendLine("{");

        if ((type.interfaces ?? []).IsEmpty())
        {
            foreach (var t in possibleTypes.DistinctBy(i => i.name))//found case where same type included twice
            {
                var typeName = GenerateTypeName(t, options);
                str.AppendLine($"public {typeName}? As{typeName}() => this as {typeName};");
            }
        }

        type.fields
            //interface shouldn't redeclare fields already declare in parent interfaces
            .Where(f => (type.interfaces ?? []).SelectMany(i => i.fields).Where(f2 => f2.name == f.name).IsEmpty())
            .ForEach(f => GenerateField(ctx, type, f, options));

        str.AppendLine("}");
    }


    private void GenerateClass(Context ctx, GraphQLType type, Dictionary<string, GraphQLType> typeNameToType, GraphQLTypeGeneratorOptions options, ILookup<string, GraphQLType> objectTypeNameToUnionTypes, (string queryType, string mutationType) rootTypes)
    {
        string className = GenerateTypeName(type, options);

        if (className == nameof(PageInfo))
            return;

        var str = ctx.StrBuilder
                        .AppendLine(GenerateDescriptionCommentAndAttribute(type.description))
                        .Append($"public class {className} : GraphQLObject<{className}>");

        if (type.name == rootTypes.queryType)
            str.Append($", IQueryRoot");

        if (type.name == rootTypes.mutationType)
            str.Append($", IMutationRoot");

        var interfaces = type.interfaces.Concat(objectTypeNameToUnionTypes[type.name]);

        if (interfaces.Any())
            str.Append($", {string.Join(',', interfaces.Select(i => this.GenerateTypeName(i, options)))}");
        if (type.name.EndsWith("Connection"))
        {
            var shallowEdgeType = type.fields.SingleOrDefault(f => f.name == "edges")?.type;
            if (shallowEdgeType != null)
            {
                while (shallowEdgeType.name == null)
                    shallowEdgeType = shallowEdgeType.ofType;
                var edgeType = typeNameToType[shallowEdgeType.name];
                var edgeTypeName = GenerateTypeName(edgeType, options);
                var nodeType = edgeType.fields.Single(f => f.name == "node").type;
                while (nodeType.name == null)
                    nodeType = nodeType.ofType;
                var nodeTypeName = GenerateTypeName(nodeType, options);

                if (type.fields.Any(f => f.name == "nodes"))
                    str.Append($", IConnectionWithNodesAndEdges<{edgeTypeName}, {nodeTypeName}>");
                else
                    str.Append($", IConnectionWithEdges<{edgeTypeName}, {nodeTypeName}>");
            }
            else
            {
                var nodeType = type.fields.SingleOrDefault(f => f.name == "nodes")?.type;
                if (nodeType != null)
                {
                    while (nodeType.name == null)
                        nodeType = nodeType.ofType;
                    var nodeTypeName = GenerateTypeName(nodeType, options);
                    str.Append($", IConnectionWithNodes<{nodeTypeName}>");
                }
            }
        }
        if (type.name.EndsWith("Edge"))
        {
            var nodeType = type.fields.Single(f => f.name == "node").type;
            var nodeTypeName = GenerateTypeName(nodeType, options);
            str.Append($", IEdge<{nodeTypeName}>");
        }
        str.AppendLine();
        str.AppendLine("{");

        type.fields
            .ForEach(f => GenerateField(ctx, type, f, options));

        str.AppendLine("}");
    }

    private void GenerateField(Context ctx, GraphQLType containingType, GraphQLField f, GraphQLTypeGeneratorOptions options)
    {
        var str = ctx.StrBuilder
                        .AppendLine(GenerateDescriptionCommentAndAttribute(f.description));
        if (f.isDeprecated)
            str.AppendLine($"[Obsolete({SymbolDisplay.FormatLiteral(f.deprecationReason.TrimEnd(), true)})]");
        if (f.type.kind == GraphQLTypeKind.NON_NULL)
            str.AppendLine($"[NonNull]");

        var kind = f.type.kind == GraphQLTypeKind.NON_NULL ? f.type.ofType.kind : f.type.kind;
        var type = f.type.kind == GraphQLTypeKind.NON_NULL ? f.type.ofType : f.type;
        if (kind == GraphQLTypeKind.ENUM && options.EnumMembersAsString)
            str.AppendLine($"[EnumType(typeof({type.name}))]");

        string typeName = GenerateTypeName(f.type, options, f.name, containingType);
        str.AppendLine($"public {typeName}? {EscapeCSharpKeyword(f.name)} {{ {(containingType.kind == GraphQLTypeKind.INTERFACE ? "get;" : "get;set;")} }}")
           .AppendLine();
    }

    private bool TryGetTypeNameOverride(GraphQLType containingType, string fieldName, GraphQLTypeGeneratorOptions options, out string typeName)
    {
        typeName = null;
        return containingType != null && options.GraphQLTypeToTypeNameOverride?.TryGetValue((containingType.name, fieldName), out typeName) == true;
    }

    // fieldName and containingType are used to get the type name override and only set in the context of generating a field
    private string GenerateTypeName(GraphQLType type, GraphQLTypeGeneratorOptions options, string fieldName = null, GraphQLType containingType = null)
    {
        if (type.kind == GraphQLTypeKind.ENUM)
        {
            if (TryGetTypeNameOverride(containingType, fieldName, options, out var overrideTypeName))
                return overrideTypeName;

            if (options.EnumMembersAsString)
                return "string";

            return type.name;
        }

        if (type.kind == GraphQLTypeKind.NON_NULL)
            return GenerateTypeName(type.ofType, options, fieldName, containingType);

        if (type.kind == GraphQLTypeKind.LIST)
            return $"IEnumerable<{GenerateTypeName(type.ofType, options, fieldName, containingType)}>";

        return (type.kind is GraphQLTypeKind.INTERFACE or GraphQLTypeKind.UNION ? "I" : string.Empty) +
                                                            (type.kind == GraphQLTypeKind.SCALAR ? this.GetScalarTypeName(fieldName, type.name, options, containingType) : type.name);
    }

    private string GetScalarTypeName(string fieldName, string typeName, GraphQLTypeGeneratorOptions options, GraphQLType containingType)
    {
        if (TryGetTypeNameOverride(containingType, fieldName, options, out var overrideTypeName))
            return overrideTypeName;

        if (options.ScalarTypeNameToDotNetTypeName?.TryGetValue(typeName, out var customTypeName) == true)
            return customTypeName;

        if (_builtInScalarNameToTypeName.TryGetValue(typeName, out var builtInTypeName))
            return builtInTypeName;

        throw new Exception($"Unknown scalar type '{typeName}'. Please provide a target type for this type.");
    }

    private void GenerateEnum(Context ctx, GraphQLType type)
    {
        var str = ctx.StrBuilder.AppendLine(GenerateDescriptionCommentAndAttribute(type.description))
                                .AppendLine($"public enum {type.name} {{");

        type.enumValues
            .ForEach(v =>
            {
                str.AppendLine(GenerateDescriptionCommentAndAttribute(v.description));
                if (v.isDeprecated)
                    str.AppendLine($"[Obsolete({SymbolDisplay.FormatLiteral(v.deprecationReason.TrimEnd(), true)})]");
                str.AppendLine($"{EscapeCSharpKeyword(v.name)},");
            });

        str.AppendLine("}");

        // Generate Enum string values
        str.AppendLine();
        str.AppendLine($"public static class {type.name}StringValues")
            .AppendLine("{");
        type.enumValues
            .ForEach(v =>
            {
                if (v.isDeprecated)
                    str.AppendLine($"[Obsolete({SymbolDisplay.FormatLiteral(v.deprecationReason.TrimEnd(), true)})]");
                str.AppendLine($"public const string {EscapeCSharpKeyword(v.name)} = @\"{v.name.Replace("\"", "\"\"")}\";");
            });
        str.AppendLine("}");
    }

    private string GenerateDescriptionCommentAndAttribute(string desc)
    {
        if (desc == null)
            return string.Empty;

        return $"""
                        ///<summary>
                        ///{SecurityElement.Escape(desc.TrimEnd('\n').Replace("\n", "\n///"))}
                        ///</summary>
                        [Description({SymbolDisplay.FormatLiteral(desc.TrimEnd('\n'), true)})]
                    """;
    }

    private string EscapeCSharpKeyword(string fieldName)
    {
        if (SyntaxFactory.ParseTokens(fieldName).First().IsKeyword())
            return "@" + fieldName;
        return fieldName;
    }
}
