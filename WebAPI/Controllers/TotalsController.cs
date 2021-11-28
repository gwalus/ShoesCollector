using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalsController : Controller
    {
        private readonly ITotalsStatisticsRepository _totalsStatisticsRepository;

        public TotalsController(ITotalsStatisticsRepository totalsStatisticsRepository)
        {
            _totalsStatisticsRepository = totalsStatisticsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<decimal>> GetTotals([FromQuery] string type)
        {
            Expression<Func<Product, double>> function = type switch
            {
                "purchase" => x => x.PurchasePrice,
                "sell" => x => x.SellingPrice ?? 0,
                "ship" => x => x.ShippingPrice ?? 0,
                "without-ship" => x => x.PriceWithoutShipping ?? 0,
                "profit" => x => x.Profit ?? 0,
                _ => null
            };

            if (function == null)
                return BadRequest("Please pass correct condition and try again.");

            return Ok(await _totalsStatisticsRepository.GetTotalsByFilterAsync(function));
        }
    }
}