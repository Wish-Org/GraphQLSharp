namespace GraphQLSharp;

public interface IRoot
{
}

public interface IMutationRoot : IRoot
{
}

public interface IQueryRoot : IRoot
{
}

public interface IQueryRootWithNode : IRoot
{
    public INode node { get; set; }
}

public interface IQueryRootWithNodeAndNodes : IQueryRootWithNode
{
    public IEnumerable<INode> nodes { get; set; }
}