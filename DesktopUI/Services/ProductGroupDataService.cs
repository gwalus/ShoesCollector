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

        public Task<List<ProductGroupData>> GetProductLossGroupData()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ProductGroupData>> GetProductPurchaseGroupData()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ProductGroupData>> GetProductSoldGroupData()
        {
            return await _restClient.CallAsync<List<ProductGroupData>>(new Domain.Helpers.Settings.RestClientSettings { Endpoint = ApiUrl.SoldGroupProductData });
        }
    }
}
