using AutoMapper;
using Domain.Entities;
using WebAPI.Dtos;

namespace WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductAddDto, Product>()
                .ForMember(dest => dest.PriceWithoutShipping, opt => opt.MapFrom(src => (src.SellingPrice - src.ShippingPrice)))
                .ForMember(dest => dest.Profit, opt => opt.MapFrom(src => (src.SellingPrice - src.ShippingPrice - src.PurchasePrice)))
                .ForMember(dest => dest.IsSold, opt => opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.SaleDate)));


            CreateMap<ProductUpdateDto, Product>()
                .ForMember(dest => dest.PriceWithoutShipping, opt => opt.MapFrom(src => (src.SellingPrice - src.ShippingPrice)))
                .ForMember(dest => dest.Profit, opt => opt.MapFrom(src => (src.SellingPrice - src.ShippingPrice - src.PurchasePrice)))
                .ForMember(dest => dest.IsSold, opt => opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.SaleDate)));

            CreateMap<BrandToAddDto, Brand>();
            CreateMap<ProductSourceToAddDto, ProductSource>();
        }
    }
}
