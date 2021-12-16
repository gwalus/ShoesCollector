using AutoMapper;
using Domain.Entities;
using WebAPI.Dtos;

namespace WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductAddDto, Product>();
        }
    }
}
