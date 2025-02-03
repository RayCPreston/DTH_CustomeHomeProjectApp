using DTH.App.Utility;
using System.Net.Http.Headers;

namespace DTH.App.Delegates
{
    public class BasicAuthHandler : DelegatingHandler
    {
        private readonly ILogger<BasicAuthHandler> _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        public BasicAuthHandler(ILogger<BasicAuthHandler> logger, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _contextAccessor = contextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                ISession? session = _contextAccessor.HttpContext?.Session;
                string credentials = HeaderUtil.CreateBasicAuthHeader(session?.GetString("Username"), session?.GetString("Password"));
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", credentials);
                return await base.SendAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"BasicAuthHandler.SendAsync exception: {ex.Message}");
                throw;
            }
        }
    }
}
