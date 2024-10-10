using services_backend.Models;

namespace services_backend.Services.Interfaces
{
    namespace services_backend.Services
    {
        public interface IEstablishmentService
        {
            Task<Establishment> CreateEstablishmentAsync(Establishment establishment);
            Task<List<Establishment>> GetAllEstablishmentsAsync();
            Task<Establishment> GetEstablishmentByIdAsync(int id);
            Task<bool> DeleteEstablishmentAsync(int id);
            Task<Establishment> UpdateEstablishmentAsync(Establishment establishment);
        }
    }

}
