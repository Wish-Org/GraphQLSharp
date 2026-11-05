namespace GraphQLSharp;

public class GraphQLHttpException : GraphQLException
{
    private const int MaxResponseBodyLengthInMessage = 1000;

    /// <summary>
    /// Raw body of the non-success response, or null when it was empty or could not be read.
    /// </summary>
    public readonly string ResponseBody;

    /// <summary>
    /// GraphQL response parsed from the body when the server returned a JSON GraphQL response
    /// (e.g. a 400 with <c>{"errors":[{"message":...}]}</c> as described by the GraphQL over HTTP spec), otherwise null.
    /// Bodies that are not GraphQL responses (proxy error pages, vendor-specific error shapes) are only available in <see cref="ResponseBody"/>.
    /// </summary>
    public readonly GraphQLResponse Response;

    public GraphQLHttpException(GraphQLRequest request, HttpResponse httpResponse, Exception ex)
        : this(request, httpResponse, ex, responseBody: null, response: null)
    {
    }

    public GraphQLHttpException(GraphQLRequest request, HttpResponse httpResponse, Exception ex, string responseBody, GraphQLResponse response)
        : base(request, httpResponse, BuildMessage(request, responseBody, response), ex)
    {
        ResponseBody = responseBody;
        Response = response;
    }

    private static string BuildMessage(GraphQLRequest request, string responseBody, GraphQLResponse response)
    {
        var message = $"""
                            GraphQL request failed with an HTTP error:
                            Request: {request}
                        """;

        if (response?.errors?.Count > 0)
            return $"{message}\nErrors: {string.Join("\n", response.errors.Select(e => e.ToString()))}";

        if (!string.IsNullOrEmpty(responseBody))
        {
            var body = responseBody.Length <= MaxResponseBodyLengthInMessage
                ? responseBody
                : $"{responseBody[..MaxResponseBodyLengthInMessage]}... (truncated)";
            return $"{message}\nResponse body: {body}";
        }

        return message;
    }
}
