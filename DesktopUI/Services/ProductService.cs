using DesktopUI.Interfaces;
using DesktopUI.ViewModels;
using Domain.Entities;
using Domain.Helpers.Settings;
using Domain.Helpers.Urls;
using Domain.Interfaces.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Ioc;
using DesktopUI.ViewModelDtos;
using System.Net;

namespace DesktopUI.Services
{
    public class ProductService : IProductService
    {
        private readonly IBaseRestClient _restClient;

        public ProductService(IBaseRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<List<Product>> GetProducts(ProductSearchFilterViewModel productSearchFilter)
        {
            return await _restClient.CallAsync<List<Product>>(GetRestClientProductTotalsSettings(productSearchFilter));
        }

        public void SetProductView(List<Product> products)
        {
            var productViewModel = ContainerLocator.Container.Resolve<ProductsViewViewModel>();

            productViewModel.Products = new System.Collections.ObjectModel.ObservableCollection<Product>(products);
        }

        private RestClientSettings GetRestClientProductTotalsSettings(ProductSearchFilterViewModel filter)
        {
            return new RestClientSettings
            {
                Endpoint = ApiUrl.Products,
                QueryStringParameters = GetQueryStringParameters(filter)
            };
        }

        private static Dictionary<string, string> GetQueryStringParameters(ProductSearchFilterViewModel filter)
        {
            var queryStringParameters = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(filter.Brand))
                queryStringParameters.Add(nameof(filter.Brand).ToLower(), filter.Brand);

            if (!string.IsNullOrWhiteSpace(filter.Name))
                queryStringParameters.Add("ProductName".ToLower(), filter.Name);

            if (!string.IsNullOrWhiteSpace(filter.Code))
                queryStringParameters.Add(nameof(filter.Code).ToLower(), filter.Code);

            if (!string.IsNullOrWhiteSpace(filter.Color))
                queryStringParameters.Add(nameof(filter.Color).ToLower(), filter.Color);

            if (!string.IsNullOrWhiteSpace(filter.Size))
                queryStringParameters.Add(nameof(filter.Size).ToLower(), filter.Size);

            if (filter.Box.HasValue)
                queryStringParameters.Add(nameof(filter.Box).ToLower(), filter.Box.ToString());

            if (!string.IsNullOrWhiteSpace(filter.Source))
                queryStringParameters.Add(nameof(filter.Source).ToLower(), filter.Source);

            return queryStringParameters;
        }

        public async Task<bool> AddProductAsync(ProductApiToAdd product)
        {
            return await _restClient.CallAsync<bool>(new RestClientSettings
            {
                Endpoint = ApiUrl.Product,
                Method = RestSharp.Method.POST,
                Payload = product
            });
        }
    }
}
