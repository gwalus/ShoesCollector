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
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandController(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        [HttpGet(ApiUrl.Brands)]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            return Ok(await _brandRepository.GetBrandsAsync());
        }

        [HttpPost(ApiUrl.Brands)]
        public async Task<ActionResult> AddBrand(BrandToAddDto brandToAddDto)
        {
            var brandToAdd = _mapper.Map<Brand>(brandToAddDto);

            return Ok(await _brandRepository.AddBrandAsync(brandToAdd));
        }
    }
}