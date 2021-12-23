using DesktopUI.Interfaces;
using Domain.Entities;
using Domain.Helpers.Urls;
using Domain.Interfaces.Clients;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopUI.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBaseRestClient _restClient;

        public BrandService(IBaseRestClient restClient)
        {
            _restClient = restClient;
        }

        public Task<bool> AddBrandAsync(Brand brand)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Brand>> GetBrandAsync()
        {
            return await _restClient.CallAsync<List<Brand>>(new Domain.Helpers.Settings.RestClientSettings
            {
                Endpoint = ApiUrl.Brands
            });
        }
    }
}
