using Domain.Helpers.Settings;
using Domain.Helpers.Urls;
using Domain.Interfaces.Clients;
using RestSharp;
using System.Linq;
using System.Threading.Tasks;

namespace DesktopUI.Services
{
    public class BaseRestClient : IBaseRestClient
    {
        private readonly IRestClient _restClient;

        public BaseRestClient(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task CallAsync(RestClientSettings clientSettings)
        {
            await CallAsync<object>(clientSettings);
        }

        public async Task<T> CallAsync<T>(RestClientSettings clientSettings) where T : new()
        {
            clientSettings.Endpoint = GetUrl(clientSettings.Endpoint);

            var request = GetRequest(clientSettings);
            var response = await BaseCallAsync<T>(request);
            
            return response.Data;
        }

        public string GetUrl(string endpoint)
        {
            return ApiUrl.BaseApiUrl + endpoint;
        }

        private static RestRequest GetRequest(RestClientSettings clientSettings)
        {
            RestRequest request = new(clientSettings.Endpoint, clientSettings.Method);

            if (clientSettings.QueryStringParameters?.Any() == true)
            {
                foreach (var parameter in clientSettings.QueryStringParameters)
                {
                    request.AddParameter(parameter.Key, parameter.Value, ParameterType.QueryString);
                }
            }

            if (clientSettings.Payload != null)
                request.AddJsonBody(clientSettings.Payload);

            return request;
        }

        private async Task<IRestResponse<T>> BaseCallAsync<T>(IRestRequest restRequest) where T : new() => await _restClient.ExecuteAsync<T>(restRequest);
    }
}