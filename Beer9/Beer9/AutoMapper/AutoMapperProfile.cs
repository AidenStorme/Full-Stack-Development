using AutoMapper;
using Beer9.Domain.Entities;
using Beer9.ViewModels;

namespace Beer9.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<Source, Destination>();
            CreateMap<Beer, BeerVM>()
                .ForMember(dest => dest.BrouwerNaam, opt => opt.MapFrom(src => src.BrouwernrNavigation.Naam))
                .ForMember(dest => dest.SoortNaam, opt => opt.MapFrom(src => src.SoortnrNavigation.Soortnaam))
                .ForMember(dest => dest.Alcohol, opt => opt.MapFrom(src => src.Alcohol.HasValue ? (double)src.Alcohol.Value : 0.0));
        }
    }
}
