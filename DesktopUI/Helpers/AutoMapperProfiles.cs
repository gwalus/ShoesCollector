using AutoMapper;
using DesktopUI.ViewModelDtos;
using DesktopUI.ViewModels;

namespace DesktopUI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddProductViewModel, ProductApiToAdd>()
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.SelectedBrand))
                .ForMember(dest => dest.Source, opt => opt.MapFrom(src => src.SelectedProductSource))
                .ForMember(dest => dest.DateOfPurchase, opt => opt.MapFrom(src => src.DateOfPurchase.ToShortDateString()))
                .ForMember(dest => dest.ProductCode, opt => opt.MapFrom(src => src.ProductCode.ToUpper()));
        }
    }
}
