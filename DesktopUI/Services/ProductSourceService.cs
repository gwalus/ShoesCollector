using DesktopUI.Interfaces;
using Domain.Entities;
using Domain.Helpers.Urls;
using Domain.Interfaces.Clients;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopUI.Services
{
    public class ProductSourceService : IProductSourceService
    {
        private readonly IBaseRestClient _restClient;

        public ProductSourceService(IBaseRestClient restClient)
        {
            _restClient = restClient;
        }

        public Task<bool> AddProductSourceAsync(ProductSource productSource)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductSource>> GetProductSourcesAsync()
        {
            return await _restClient.CallAsync<List<ProductSource>>(new Domain.Helpers.Settings.RestClientSettings
            {
                Endpoint = ApiUrl.ProductSources
            });
        }
    }
}
