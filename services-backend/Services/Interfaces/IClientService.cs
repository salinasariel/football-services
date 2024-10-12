using System.Collections.Generic;
using System.Threading.Tasks;

namespace services_backend.Services.Interfaces
{
    public interface IClientService
    {
        Task<List<Client>> GetAllClients();
        Task<Client> GetClientById(int Id);
        Task<Client> NewClient(Client client);
        Task<Client> ChangeState(int Id, int newState);
        Task<Client> BanClient(int Id, int newBan);
        Task<List<Client>> GetClientsByEstablishment(int EstablishmentId);
        Task<Client> GetClientByPhone(string phone);
    }
}
