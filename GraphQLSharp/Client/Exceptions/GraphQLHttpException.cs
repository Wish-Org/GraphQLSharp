namespace GraphQLSharp;

public class GraphQLHttpException : GraphQLException
{
    public IReadOnlyList<string> Errors { get; }

    public GraphQLHttpException(GraphQLRequest request, HttpResponse httpResponse, Exception ex)
        : this(new GraphQLHttpError { Request = request, HttpResponse = httpResponse }, ex)
    {
    }

    public GraphQLHttpException(GraphQLHttpError error, Exception ex)
        : base(error.Request, error.HttpResponse, $"""
                            GraphQL request failed with an HTTP error: {(error.errors != null ? string.Join("\n", error.errors) : "")}
                            Request: {error.Request}
                        """, ex)
    {
        Errors = Array.AsReadOnly(error.errors?.ToArray() ?? Array.Empty<string>());
    }
}
