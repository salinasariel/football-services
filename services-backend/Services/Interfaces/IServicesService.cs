using services_backend.Models;

namespace services_backend.Services.Interfaces
{
    public interface IServicesService
    {
        Task<List<Service>> GetAllServices();
        Task<Service> GetTypeServicesById(int Id);
        Task<Service> NewServices(Service Service);
        Task<Service> ChangeServicesState(int Id, int newState);
        
    }
}
