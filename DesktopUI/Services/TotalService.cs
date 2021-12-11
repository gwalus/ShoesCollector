using DesktopUI.Interfaces;
using DesktopUI.ViewModels;
using Domain.Helpers.Enums;
using Domain.Helpers.Settings;
using Domain.Helpers.Urls;
using Domain.Interfaces.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Ioc;

namespace DesktopUI.Services
{
    public class TotalService : ITotalService
    {
        private readonly IBaseRestClient _restClient;

        public TotalService(IBaseRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<int> GetTotalCount(bool? isSold = null)
        {
            var restClientSettings = new RestClientSettings { Endpoint = ApiUrl.ProductsQuantity};

            if (isSold.HasValue)
            {
                var queryStringParameters = new Dictionary<string, string>();
                queryStringParameters.Add("isSold", isSold.ToString());

                restClientSettings.QueryStringParameters = queryStringParameters;
            }
            return await _restClient.CallAsync<int>(restClientSettings);
        }

        public async Task<double> GetTotalPurchase(bool? isSold = null)
        {
            return await _restClient.CallAsync<double>(GetRestClientProductTotalsSettings(ProductTotalType.Purchase, isSold));
        }

        public async Task<double> GetTotalSell(bool? isSold = null)
        {
            return await _restClient.CallAsync<double>(GetRestClientProductTotalsSettings(ProductTotalType.Sell, isSold));
        }

        public async Task<double> GetTotalShip(bool? isSold = null)
        {
            return await _restClient.CallAsync<double>(GetRestClientProductTotalsSettings(ProductTotalType.Ship, isSold));
        }

        public async Task<double> GetTotalWithoutShip(bool? isSold = null)
        {
            return await _restClient.CallAsync<double>(GetRestClientProductTotalsSettings(ProductTotalType.WithoutShip, isSold));
        }

        public async Task<double> GetTotalProfit(bool? isSold = null)
        {
            return await _restClient.CallAsync<double>(GetRestClientProductTotalsSettings(ProductTotalType.Profit, isSold));
        }
        public void SetProductTotalsView(bool? isSold = null, string description = null)
        {
            var productTotalsModel = ContainerLocator.Container.Resolve<ProductTotalViewModel>();

            productTotalsModel.QuantityTotal = Task.Run(async () => await GetTotalCount(isSold)).Result;
            productTotalsModel.PurchaseTotal = Task.Run(async () => await GetTotalPurchase(isSold)).Result;
            productTotalsModel.SellTotal = Task.Run(async () => await GetTotalSell(isSold)).Result;
            productTotalsModel.ShipTotal = Task.Run(async () => await GetTotalShip(isSold)).Result;
            productTotalsModel.WithoutShipTotal = Task.Run(async () => await GetTotalWithoutShip(isSold)).Result;
            productTotalsModel.ProfitTotal = Task.Run(async () => await GetTotalProfit(isSold)).Result;

            productTotalsModel.Description = $"Totals: ({description.ToLower()})";
        }

        private RestClientSettings GetRestClientProductTotalsSettings(ProductTotalType type, bool? isSold)
        {
            return new RestClientSettings
            {
                Endpoint = ApiUrl.Totals,
                QueryStringParameters = GetQueryStringParameters(type, isSold)
            };
        }

        private static Dictionary<string, string> GetQueryStringParameters(ProductTotalType type, bool? isSold)
        {
            var queryStringParameters = new Dictionary<string, string>
            {
                { "type", type.ToString().ToLower() }
            };

            if (isSold.HasValue)
                queryStringParameters.Add("isSold", isSold.ToString());

            return queryStringParameters;
        }
    }
}
