using DesktopUI.Interfaces;
using Domain.Dtos;
using Domain.Helpers.Urls;
using Domain.Interfaces.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopUI.Services
{
    public class ProductGroupDataService : IProductGroupDataService
    {
        private readonly IBaseRestClient _restClient;

        public ProductGroupDataService(IBaseRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<List<ProductGroupData>> GetProductLossGroupData()
        {
            return await _restClient.CallAsync<List<ProductGroupData>>(new Domain.Helpers.Settings.RestClientSettings { Endpoint = ApiUrl.LossGroupProductData });
        }

        public async Task<List<ProductGroupData>> GetProductPurchaseGroupData()
        {
            return await _restClient.CallAsync<List<ProductGroupData>>(new Domain.Helpers.Settings.RestClientSettings { Endpoint = ApiUrl.PurchaseGroupProductData });
        }

        public async Task<List<ProductGroupData>> GetProductSoldGroupData()
        {
            return await _restClient.CallAsync<List<ProductGroupData>>(new Domain.Helpers.Settings.RestClientSettings { Endpoint = ApiUrl.SoldGroupProductData });
        }
    }
}
