using Domain.Dtos;
using Domain.Helpers.Urls;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    public class ChartSeriesController : ControllerBase
    {
        private readonly IChartRepository _chartRepository;

        public ChartSeriesController(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }

        [HttpGet(ApiUrl.ChartBrands)]
        public async Task<ActionResult<List<ChartBrandSeriesDto>>> GetBrandSeries()
        {
            return Ok(await _chartRepository.GetChartBrandSeriesAsync());
        }

        [HttpGet(ApiUrl.ChartSizes)]
        public async Task<ActionResult<List<ChartBrandSeriesDto>>> GetSizesSeries()
        {
            return Ok(await _chartRepository.GetChartSizeSeriesAsync());
        }

        [HttpGet(ApiUrl.ChartColor)]
        public async Task<ActionResult<List<ChartBrandSeriesDto>>> GetColorSeries()
        {
            return Ok(await _chartRepository.GetChartColorSeriesAsync());
        }
    }
}
