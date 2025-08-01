public class TestHttpClient : HttpClient
{
    public TestHttpClient(Func<HttpRequestMessage, HttpResponseMessage> responseFactory)
        : base(new TestHttpMessageHandler(responseFactory))
    {
    }

    private class TestHttpMessageHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, HttpResponseMessage> _responseFactory;

        public TestHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> responseFactory)
        {
            _responseFactory = responseFactory;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = _responseFactory(request);
            response.RequestMessage = request;
            return Task.FromResult(response);
        }
    }
}

