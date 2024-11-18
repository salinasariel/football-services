using AutoMapper;
using services_backend.Models;
using services_backend.DTOs;

namespace services_backend.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EstablishmentDto, Establishment>()
                .ForMember(dest => dest.IdEstablishment, opt => opt.Ignore()) 
                .ForMember(dest => dest.Clients, opt => opt.Ignore()) 
                .ForMember(dest => dest.Services, opt => opt.Ignore())
                .ForMember(dest => dest.TypeServices, opt => opt.Ignore());

            CreateMap<TypeServiceDto, TypeService>()
                .ForMember(dest => dest.Establishment, opt => opt.Ignore()) 
                .ForMember(dest => dest.Services, opt => opt.Ignore());

            CreateMap<ServiceDto, Service>()
                .ForMember(dest => dest.Establishment, opt => opt.Ignore()) 
                .ForMember(dest => dest.TypeService, opt => opt.Ignore());

        }
    }
}
