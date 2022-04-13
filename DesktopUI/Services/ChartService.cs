using DesktopUI.Interfaces;
using Domain.Dtos;
using Domain.Helpers.Urls;
using Domain.Interfaces.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopUI.Services
{
    public class ChartService : IChartService
    {
        private readonly IBaseRestClient _restClient;

        public ChartService(IBaseRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<List<ChartBrandSeriesDto>> GetChartBrandSeries()
        {
            return await _restClient.CallAsync<List<ChartBrandSeriesDto>>(new Domain.Helpers.Settings.RestClientSettings
            {
                Endpoint = ApiUrl.ChartBrands
            });
        }

        public async Task<List<ChartColorSeriesDto>> GetChartColorSeries()
        {
            return await _restClient.CallAsync<List<ChartColorSeriesDto>>(new Domain.Helpers.Settings.RestClientSettings
            {
                Endpoint = ApiUrl.ChartColor
            });
        }

        public async Task<List<ChartSizeSeriesDto>> GetChartSizesSeries()
        {
            return await _restClient.CallAsync<List<ChartSizeSeriesDto>>(new Domain.Helpers.Settings.RestClientSettings
            {
                Endpoint = ApiUrl.ChartSizes
            });
        }
    }
}
