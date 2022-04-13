using Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IChartRepository
    {
        Task<List<ChartBrandSeriesDto>> GetChartBrandSeriesAsync();
        Task<List<ChartSizeSeriesDto>> GetChartSizeSeriesAsync();
        Task<List<ChartColorSeriesDto>> GetChartColorSeriesAsync();
    }
}
