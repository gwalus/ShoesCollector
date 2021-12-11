using Domain.Entities;
using Domain.Helpers.Urls;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    public class TotalsController : ControllerBase
    {
        private readonly ITotalsStatisticsRepository _totalsStatisticsRepository;

        public TotalsController(ITotalsStatisticsRepository totalsStatisticsRepository)
        {
            _totalsStatisticsRepository = totalsStatisticsRepository;
        }

        [HttpGet(ApiUrl.Totals)]
        public async Task<ActionResult<decimal>> GetTotals([FromQuery] string type, [FromQuery]bool? isSold)
        {
            Expression<Func<Product, double>> function = type switch
            {
                "purchase" => x => x.PurchasePrice,
                "sell" => x => x.SellingPrice ?? 0,
                "ship" => x => x.ShippingPrice ?? 0,
                "withoutship" => x => x.PriceWithoutShipping ?? 0,
                "profit" => x => x.Profit ?? 0,
                _ => null
            };

            if (function == null)
                return BadRequest("Please pass correct condition and try again.");

            return Ok(await _totalsStatisticsRepository.GetTotalsByFilterAsync(function, isSold));
        }

        [HttpGet(ApiUrl.ProductsQuantity)]
        public async Task<ActionResult<int>> GetCount([FromQuery] bool? isSold)
        {
            return Ok(await _totalsStatisticsRepository.CountProducts(isSold));
        }
    }
}