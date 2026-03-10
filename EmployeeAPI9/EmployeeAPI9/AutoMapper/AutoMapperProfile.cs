using AutoMapper;
using EmployeeAPI9.Domain.EntitiesDB;
using EmployeeAPI9.ViewModels;

namespace EmployeeAPI9.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // CreateMap<TSource, TDestination>;
        CreateMap<Employee, EmployeeVM>()
            .ForMember(x => x.Name, opt => opt.MapFrom(y => y.Name.Trim()))
            .ForMember(x => x.Address, opt => opt.MapFrom(y => y.Address.Trim()))
            .ForMember(x => x.CompanyName, opt => opt.MapFrom(y => y.CompanyName.Trim()))
            .ForMember(x => x.Designation, opt => opt.MapFrom(y => y.Designation.Trim()));
        
        // CreateMap<TSource, TDestination>;
        CreateMap<EmployeePostVM, Employee>()
            .ForMember(x => x.EmployeeId, opt => opt.Ignore());
    }
     
}