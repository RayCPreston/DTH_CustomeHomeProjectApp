namespace DTH.App.Interfaces
{
    public interface IRestRequestService
    {
        HttpResponseMessage GetAsync(string requestUri);
        HttpResponseMessage PostAsync(string requestUri, string requestBody);
        HttpResponseMessage PutAsync(string requestUri, string requestBody);
        HttpResponseMessage DeleteAsync(string requestUri);
    }
}
