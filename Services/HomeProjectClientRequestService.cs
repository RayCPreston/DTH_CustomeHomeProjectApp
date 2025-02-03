using System.Text;
using System.Net;
using DTH.App.Interfaces;

namespace DTH.App.Services
{
    public class HomeProjectClientRequestService : IRestRequestService
    {
        private readonly ILogger<HomeProjectClientRequestService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeProjectClientRequestService(ILogger<HomeProjectClientRequestService> logger,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Sends a DELETE request using the &quot;home-project&quot; httpClient
        /// </summary>
        /// <param name="requestUri">string</param>
        /// <returns>HttpResponseMessage</returns>
        public HttpResponseMessage DeleteAsync(string requestUri)
        {
            try
            {
                HttpClient client = GetClient();
                HttpResponseMessage response = client.DeleteAsync(requestUri).Result;
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception in HomeProjectClientRequestService.DeleteAsync.  Message: {ex.Message}");
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        /// <summary>
        /// Sends a GET request using the &quot;home-project&quot; httpClient
        /// </summary>
        /// <param name="requestUri">string</param>
        /// <returns>HttpResponseMessage</returns>
        public HttpResponseMessage GetAsync(string requestUri)
        {
            try
            {
                HttpClient client = GetClient();
                HttpResponseMessage response = client.GetAsync(requestUri).Result;
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception in HomeProjectClientRequestService.GetAsync.  Message: {ex.Message}");
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        /// <summary>
        /// Sends a POST request using the &quot;home-project&quot; httpClient
        /// </summary>
        /// <param name="requestUri">string</param>
        /// <param name="requestBody">string</param>
        /// <returns>HttpResponseMessage</returns>
        public HttpResponseMessage PostAsync(string requestUri, string requestBody)
        {
            try
            {
                HttpClient client = GetClient();
                HttpResponseMessage response = client.PostAsync(requestUri, CreateHttpContent(requestBody)).Result;
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception in HomeProjectClientRequestService.PostAsync.  Message: {ex.Message}");
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        /// <summary>
        /// Sends a PUT request using the &quot;home-project&quot; httpClient
        /// </summary>
        /// <param name="requestUri">string</param>
        /// <param name="requestBody">string</param>
        /// <returns>HttpResponseMessage</returns>
        public HttpResponseMessage PutAsync(string requestUri, string requestBody)
        {
            try
            {
                HttpClient client = GetClient();
                HttpResponseMessage response = client.PutAsync(requestUri, CreateHttpContent(requestBody)).Result;
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception in HomeProjectClientRequestService.PutAsync.  Message: {ex.Message}");
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        private HttpClient GetClient()
        {
            return _httpClientFactory.CreateClient("homeproject-client");
        }

        private HttpContent CreateHttpContent(string requestBody)
        {
            return new StringContent(requestBody, Encoding.UTF8, "application/json");
        }
    }
}
