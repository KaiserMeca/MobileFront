using AutoMapper;
using MobileFront.Models;
using MobileFront.Models.DTOs;

namespace MobileFront
{
    /// <summary>
    /// AutoMapper that defines the conversions between the Asset and the AssetDTO
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Create a new instance of MappingProfile and define the mapping settings
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Asset, AssetDTO>()
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => (DepartmentEnum)src.Department));
            CreateMap<RemainingLifespan, RemainingLifespanDTO>()
                .ForMember(dest => dest.RemainingDuration, opt => opt.MapFrom(src => src.RemainingDuration));
        }
    }
}
