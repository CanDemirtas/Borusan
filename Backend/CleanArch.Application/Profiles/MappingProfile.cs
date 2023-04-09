using AutoMapper;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<MaterialViewModel, Material>()
                 .ForMember(x => x.LastModifiedDate, opt => opt.Ignore())
                 .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                 .ReverseMap();

            CreateMap<OrderViewModel, Order>()
                 .ForMember(x => x.LastModifiedDate, opt => opt.Ignore())
                 .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                 .ReverseMap();
        }
    }
}