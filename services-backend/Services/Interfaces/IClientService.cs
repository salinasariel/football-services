namespace services_backend.Services.Interfaces
{
    public interface IClientService
    {
        Task<List<Client>> GetAllClients();

        Task<Client> GetClientById(int Id);

        Task<Client> NewClient(Client client);

        Task<Client> BanClient(int Id, int newBan);

        Task<Client> ChangeState(int Id, int newState);
    }
}
