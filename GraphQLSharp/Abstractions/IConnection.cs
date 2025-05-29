using System.Collections;

namespace GraphQLSharp;

#nullable enable

public interface IConnection
{
    PageInfo? pageInfo { get; set; }
    Type GetNodeType();
    IEnumerable? GetNodes();
}

public interface IConnectionWithNodes : IConnection
{
    IEnumerable? nodes { get; set; }
    IEnumerable? IConnection.GetNodes() => this.nodes;
}

public interface IConnectionWithNodes<TNode> : IConnectionWithNodes
{
    IEnumerable? IConnectionWithNodes.nodes
    {
        get => this.nodes;
        set => this.nodes = (IEnumerable<TNode>?)value;
    }
    new IEnumerable<TNode>? nodes { get; set; }
    Type IConnection.GetNodeType() => typeof(TNode);
}

public interface IConnectionWithEdges : IConnection
{
    IEnumerable<IEdge>? edges { get; set; }
    Type GetEdgeType();
    IEnumerable? IConnection.GetNodes() => this.edges?.Select(e => e.node);
}

public interface IConnectionWithEdges<TNode> : IConnectionWithEdges
{
    IEnumerable<IEdge>? IConnectionWithEdges.edges
    {
        get => this.edges;
        set => this.edges = (IEnumerable<IEdge<TNode>>?)value;
    }
    new IEnumerable<IEdge<TNode>>? edges { get; set; }
    Type IConnection.GetNodeType() => typeof(TNode);
}

public interface IConnectionWithEdges<TEdge, TNode> : IConnectionWithEdges<TNode> where TEdge : IEdge<TNode>
{
    IEnumerable<IEdge<TNode>>? IConnectionWithEdges<TNode>.edges
    {
        get => this.edges?.Cast<IEdge<TNode>>();
        set => this.edges = value?.Cast<TEdge>();
    }
    new IEnumerable<TEdge>? edges { get; set; }
    Type IConnectionWithEdges.GetEdgeType() => typeof(TEdge);
}

public interface IConnectionWithNodesAndEdges<TEdge, TNode> : IConnectionWithEdges<TEdge, TNode>, IConnectionWithNodes<TNode> where TEdge : IEdge<TNode>
{
    Type IConnection.GetNodeType() => typeof(TNode);
    IEnumerable? IConnection.GetNodes() => this.nodes ?? this.edges?.Select(e => e.node);
}