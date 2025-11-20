using AutoMapper;
using PartialView.Domain.EntitiesDB;
using PartialView9.ViewModels;

namespace PartialView9.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Adult, AdultVM>();

            CreateMap<Adult, AdultVM>()
                .ForMember(dest => dest.DepartmentName,
                opts => opts.MapFrom(
                    src => src.Department.DepartmentName
                )); // Hier toon je aan je mapper waar hij die departmentname vandaan moet halen
        }
    }
}
