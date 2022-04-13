using Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopUI.Interfaces
{
    public interface IChartService
    {
        Task<List<ChartBrandSeriesDto>> GetChartBrandSeries();
        Task<List<ChartSizeSeriesDto>> GetChartSizesSeries();
        Task<List<ChartColorSeriesDto>> GetChartColorSeries();
    }
}
