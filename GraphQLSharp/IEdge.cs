namespace GraphQLSharp;

#nullable enable

public interface IEdge
{
    string? cursor { get; set; }

    object? node { get; set; }
}

public interface IEdge<TNode> : IEdge
{
    object? IEdge.node
    {
        get => this.node;
        set => this.node = (TNode?)value;
    }
    new TNode? node { get; set; }
}