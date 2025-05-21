namespace GraphQLSharp;

#nullable enable

public interface IGraphQLObject
{
}

public abstract class GraphQLObject<TSelf> : IGraphQLObject where TSelf : GraphQLObject<TSelf>
{
    public static TSelf? FromJson(string json) => Serializer.Deserialize<TSelf>(json);
}

public static class GraphQLObjectExtensions
{
    public static string ToJson(this IGraphQLObject o) => Serializer.Serialize(o);
}