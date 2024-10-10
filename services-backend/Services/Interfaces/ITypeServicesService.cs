using services_backend.Models;

namespace services_backend.Services.Interfaces
{
    public interface ITypeServicesService
    {
        Task<List<TypeService>> GetAllTypeServices();
        Task<TypeService> GetTypeServicesById(int Id);
        Task<TypeService> NewTypeServices(TypeService TypeService);
        Task<TypeService> ChangeTypeServicesState(int Id, int newState);

    }
}
