using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphQLSharp.Tests;

[TestClass]
public class GraphQLHttpExceptionTests
{
    [TestMethod]
    public void OriginalPublicConstructorPreservesMetadata()
    {
        var constructor = typeof(GraphQLHttpException).GetConstructor(
            new[] { typeof(GraphQLRequest), typeof(HttpResponse), typeof(Exception) });
        Assert.IsNotNull(constructor, "Retain the original public constructor for existing consumers.");
        GraphQLRequest request = "{ shop { id } }";
        using var responseMessage = new HttpResponseMessage(HttpStatusCode.BadGateway);
        var response = new HttpResponse(responseMessage);
        var innerException = new HttpRequestException("Bad gateway");

        var exception = (GraphQLHttpException)constructor.Invoke(new object[] { request, response, innerException });

        Assert.AreSame(request, exception.Request);
        Assert.AreSame(response, exception.HttpResponse);
        Assert.AreSame(innerException, exception.InnerException);
        Assert.AreEqual(0, exception.Errors.Count);
        StringAssert.Contains(exception.Message, request.ToString());
    }
}
