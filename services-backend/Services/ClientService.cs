using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using services_backend.Services.Interfaces;

namespace services_backend.Services
{
    public class ClientService : IClientService
    {
        private readonly MyDbContext _context;

        public ClientService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetAllClients()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientById(int Id)
        {
            return await _context.Clients.FindAsync(Id);
        }

        public async Task<Client> NewClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

       public async Task<Client> ChangeState(int Id, int newState)
        {
            var client = await _context.Clients.FindAsync(Id);
            if (client == null)
            {
                throw new Exception($"Client with ID {Id} not found.");
            }
            client.State = newState;
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client> BanClient(int Id, int newBan)
        {
            var client = await _context.Clients.FindAsync(Id);
            if (client == null)
            {
                throw new Exception($"Client with ID {Id} not found.");  
            }
            client.Ban = newBan;
            await _context.SaveChangesAsync();
            return client;
        }
        public async Task<List<Client>> GetClientsByEstablishment(int EstablishmentId)
        {
            var clients = await _context.Clients
                                        .Where(c => c.EstablishmentId == EstablishmentId)
                                        .ToListAsync();

            if (clients == null || clients.Count == 0)
            {
                throw new Exception($"No clients found for Establishment ID {EstablishmentId}.");
            }

            return clients;
        }

        public async Task<Client> GetClientByPhone(string phone)
        {
            var client = await _context.Clients
                                .FirstOrDefaultAsync(c => c.Phone == phone);
            if (client == null)
            {
                return client;
            }
            return client;
        }

    }
}
