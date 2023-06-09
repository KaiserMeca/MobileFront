using AutoMapper;
using MobileFront.Models;
using MobileFront.Models.DTOs;


namespace MobileFront
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Asset, AssetDTO>()
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => (DepartmentEnum)src.Department));
            CreateMap<RemainingLifespan, RemainingLifespanDTO>()
                .ForMember(dest => dest.RemainingDuration, opt => opt.MapFrom(src => src.RemainingDuration));
        }
    }
}

