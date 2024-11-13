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
                .ForMember(dest => dest.IdEstablishment, opt => opt.Ignore()) // Ignorar el campo Id (si es autogenerado)
                .ForMember(dest => dest.Clients, opt => opt.Ignore()) // Ignorar relaciones
                .ForMember(dest => dest.Services, opt => opt.Ignore())
                .ForMember(dest => dest.TypeServices, opt => opt.Ignore());
        }
    }
}
