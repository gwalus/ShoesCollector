using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IProductStatisticsRepository _productStatisticsRepository;
        private readonly IProductDatesStatisticsRepository _productDatesStatisticsRepository;
        private readonly IProductPricesStatisticsRepository _productPricesStatisticsRepository;

        public StatisticsController(IProductStatisticsRepository productStatisticsRepository, IProductDatesStatisticsRepository productDatesStatisticsRepository, IProductPricesStatisticsRepository productPricesStatisticsRepository)
        {
            _productStatisticsRepository = productStatisticsRepository;
            _productDatesStatisticsRepository = productDatesStatisticsRepository;
            _productPricesStatisticsRepository = productPricesStatisticsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Product>> GetFirstFurchase()
        {
            return Ok(await _productStatisticsRepository.GetFirstPurchaseAsync());
        }

        [HttpGet]
        public async Task<ActionResult<Product>> GetLatestPurchase()
        {
            return Ok(await _productStatisticsRepository.GetLatestPurchaseAsync());
        }
    }
}
