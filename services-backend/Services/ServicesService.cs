using Microsoft.EntityFrameworkCore;
using services_backend.Models;
using services_backend.Services.Interfaces;

namespace services_backend.Services
{
    public class ServicesService : IServicesService
    {
        private readonly MyDbContext _context;

        public ServicesService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Service>> GetAllServices()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Service> GetTypeServicesById(int Id)
        {
            return await _context.Services.FindAsync(Id);
        }

        public async Task<Service> NewServices(Service Service)
        {
            _context.Services.Add(Service);
            await _context.SaveChangesAsync();
            return Service;
        }

        public async Task<Service> ChangeServicesState(int Id, int newState)
        {
            var Servi = await _context.Services.FindAsync(Id);
            if (Servi == null)
            {
                throw new Exception($"Service with ID {Id} not found.");
            }
            Servi.State = newState;
            await _context.SaveChangesAsync();
            return Servi;
        }


    }
}
