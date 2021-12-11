using Domain.Entities;
using Domain.Helpers.Filters;
using Domain.Helpers.Urls;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet(ApiUrl.Products)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync([FromQuery]ProductFilter productFilter)
        {
            return Ok(await _productRepository.GetAll(productFilter));
        }
    }
}
