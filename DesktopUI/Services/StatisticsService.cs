using DesktopUI.Interfaces;
using Domain.Entities;
using Domain.Helpers.Settings;
using Domain.Helpers.Urls;
using Domain.Interfaces.Clients;
using System.Threading.Tasks;

namespace DesktopUI.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IBaseRestClient _restClient;

        public StatisticsService(IBaseRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<double> GetBestProfit()
        {
            return await _restClient.CallAsync<double>(new RestClientSettings { Endpoint = ApiUrl.BestProfit});
        }

        public async Task<int> GetDaysOfFirstPurchase()
        {
            return await _restClient.CallAsync<int>(new RestClientSettings { Endpoint = ApiUrl.DaysOfFirstPurchase });
        }

        public async Task<int> GetDaysOfLatestPurchase()
        {
            return await _restClient.CallAsync<int>(new RestClientSettings { Endpoint = ApiUrl.DaysOfLatestPurchase });
        }

        public async Task<int> GetDaysOfLatestSale()
        {
            return await _restClient.CallAsync<int>(new RestClientSettings { Endpoint = ApiUrl.DaysOfLatestSale });
        }

        public async Task<Product> GetFirstPurchase()
        {
            return await _restClient.CallAsync<Product>(new RestClientSettings { Endpoint = ApiUrl.FirstPurchase});
        }

        public async Task<Product> GetLatestPurchase()
        {
            return await _restClient.CallAsync<Product>(new RestClientSettings { Endpoint = ApiUrl.LatestPurchase });
        }

        public async Task<Product> GetLatestSale()
        {
            return await _restClient.CallAsync<Product>(new RestClientSettings { Endpoint = ApiUrl.LatestSale });
        }

        public async Task<double> GetLowestProfit()
        {
            return await _restClient.CallAsync<double>(new RestClientSettings { Endpoint = ApiUrl.LowestProfit });
        }
    }
}
