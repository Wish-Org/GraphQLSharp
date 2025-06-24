using System.Net;
using System.Net.Http.Headers;

namespace GraphQLSharp;

public class HttpResponse
{
    public readonly HttpStatusCode StatusCode;
    public readonly HttpResponseHeaders Headers;

    public HttpResponse(HttpResponseMessage r)
    {
        this.StatusCode = r.StatusCode;
        this.Headers = r.Headers;
    }
}