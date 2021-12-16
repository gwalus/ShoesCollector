using AutoMapper;
using Domain.Entities;
using Domain.Helpers.Filters;
using Domain.Helpers.Urls;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Dtos;

namespace WebAPI.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet(ApiUrl.Products)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync([FromQuery]ProductFilter productFilter)
        {
            return Ok(await _productRepository.GetAllAsync(productFilter));
        }

        [HttpPost(ApiUrl.Product)]
        public async Task<ActionResult> AddProduct([FromBody] ProductAddDto productAddDto)
        {
            var productToAdd = _mapper.Map<Product>(productAddDto);

            if (await _productRepository.AddAsync(productToAdd))
                return Ok("Product has been added");

            return BadRequest();
        }

        [HttpPut(ApiUrl.Product)]
        public async Task<ActionResult> UpdateProduct([FromBody] ProductUpdateDto productUpdateDto)
        {
            var productToUpdate = _mapper.Map<Product>(productUpdateDto);

            if (await _productRepository.AddAsync(productToUpdate))
                return Ok("Product has been added");

            return BadRequest();
        }
    }
}
