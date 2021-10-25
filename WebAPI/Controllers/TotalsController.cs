using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
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
            switch (type)
            {
                case "purchase":
                    return Ok(await _totalsStatisticsRepository.GetTotalsByFilterAsync(x => x.PurchasePrice));
                case "sell":
                    return Ok(await _totalsStatisticsRepository.GetTotalsByFilterAsync(x => x.SellingPrice.Value));
                case "ship":
                    return Ok(await _totalsStatisticsRepository.GetTotalsByFilterAsync(x => x.ShippingPrice.Value));
                case "without-ship":
                    return Ok(await _totalsStatisticsRepository.GetTotalsByFilterAsync(x => x.PriceWithoutShipping.Value));
                case "profit":
                    return Ok(await _totalsStatisticsRepository.GetTotalsByFilterAsync(x => x.Profit.Value));
                default:
                    return BadRequest("Choose a type to get total statistics");
            }
        }
    }
}