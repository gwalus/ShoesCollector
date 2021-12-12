using Domain.Dtos;
using Domain.Entities;
using Domain.Helpers.Urls;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IProductStatisticsRepository _productStatisticsRepository;
        private readonly IProductDatesStatisticsRepository _productDatesStatisticsRepository;
        private readonly IProductPricesStatisticsRepository _productPricesStatisticsRepository;
        private readonly IProductGroupDataRepository _productGroupDataRepository;

        public StatisticsController(IProductStatisticsRepository productStatisticsRepository, IProductDatesStatisticsRepository productDatesStatisticsRepository, 
            IProductPricesStatisticsRepository productPricesStatisticsRepository, IProductGroupDataRepository productGroupDataRepository)
        {
            _productStatisticsRepository = productStatisticsRepository;
            _productDatesStatisticsRepository = productDatesStatisticsRepository;
            _productPricesStatisticsRepository = productPricesStatisticsRepository;
            _productGroupDataRepository = productGroupDataRepository;
        }

        [HttpGet(ApiUrl.FirstPurchase)]
        public async Task<ActionResult<Product>> GetFirstFurchase()
        {
            return Ok(await _productStatisticsRepository.GetFirstPurchaseAsync());
        }

        [HttpGet(ApiUrl.LatestPurchase)]
        public async Task<ActionResult<Product>> GetLatestPurchase()
        {
            return Ok(await _productStatisticsRepository.GetLatestPurchaseAsync());
        }

        [HttpGet(ApiUrl.LatestSale)]
        public async Task<ActionResult<Product>> GetLatestSale()
        {
            return Ok(await _productStatisticsRepository.GetLatestSaleAsync());
        }

        [HttpGet(ApiUrl.DaysOfFirstPurchase)]
        public async Task<ActionResult<Product>> GetDaysOfFirstPurchase()
        {
            return Ok(await _productDatesStatisticsRepository.GetDaysOfFirstPurchaseAsync());
        }

        [HttpGet(ApiUrl.DaysOfLatestPurchase)]
        public async Task<ActionResult<Product>> GetDaysOfLatestPurchase()
        {
            return Ok(await _productDatesStatisticsRepository.GetDaysOfLatestPurchaseAsync());
        }

        [HttpGet(ApiUrl.DaysOfLatestSale)]
        public async Task<ActionResult<Product>> GetDaysOfLatestSale()
        {
            return Ok(await _productDatesStatisticsRepository.GetDaysOfLatestSaleAsync());
        }

        [HttpGet(ApiUrl.BestProfit)]
        public async Task<ActionResult<Product>> GetBestProfit()
        {
            return Ok(await _productPricesStatisticsRepository.GetBestProfitAsync());
        }

        [HttpGet(ApiUrl.LowestProfit)]
        public async Task<ActionResult<Product>> GetLowestProfit()
        {
            return Ok(await _productPricesStatisticsRepository.GetLowestProfitAsync());
        }

        [HttpGet(ApiUrl.BiggestPurchase)]
        public async Task<ActionResult<Product>> GetBiggestPurchase()
        {
            return Ok(await _productPricesStatisticsRepository.GetBiggestPurchaseAsync());
        }

        [HttpGet(ApiUrl.LowestPurchase)]
        public async Task<ActionResult<Product>> GetLowestPurchase()
        {
            return Ok(await _productPricesStatisticsRepository.GetLowestPurchaseAsync());
        }

        [HttpGet(ApiUrl.SoldGroupProductData)]
        public async Task<ActionResult<List<ProductGroupData>>> GetSoldProductGroupData()
        {
            return Ok(await _productGroupDataRepository.GetSoldProductGroupData());
        }
    }
}
