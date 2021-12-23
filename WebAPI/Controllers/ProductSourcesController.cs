using AutoMapper;
using Domain.Entities;
using Domain.Helpers.Urls;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Dtos;

namespace WebAPI.Controllers
{
    [ApiController]
    public class ProductSourcesController : ControllerBase
    {
        private readonly IProductSourceRepository _productSourceRepository;
        private readonly IMapper _mapper;

        public ProductSourcesController(IProductSourceRepository productSourceRepository, IMapper mapper)
        {
            _productSourceRepository = productSourceRepository;
            _mapper = mapper;
        }

        [HttpGet(ApiUrl.ProductSources)]
        public async Task<ActionResult<List<ProductSource>>> GetProductSources()
        {
            return Ok(await _productSourceRepository.GetProductSourcesAsync());
        }

        [HttpPost(ApiUrl.ProductSources)]
        public async Task<ActionResult> AddProductSource(ProductSourceToAddDto productSourceToAddDto)
        {
            var productSourceToAdd = _mapper.Map<ProductSource>(productSourceToAddDto);

            return Ok(await _productSourceRepository.AddProductSourceAsync(productSourceToAdd));
        }
    }
}
