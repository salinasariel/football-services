using Microsoft.EntityFrameworkCore;
using services_backend.Models;

namespace services_backend.Services
{
    public class TypeServicesService
    {
        private readonly MyDbContext _context;

        public TypeServicesService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<TypeService>> GetAllTypeServices()
        {
            return await _context.TypeServices.ToListAsync();
        }

        public async Task<TypeService> GetTypeServicesById(int Id)
        {
            return await _context.TypeServices.FindAsync(Id);
        }

        public async Task<TypeService> NewTypeServices(TypeService TypeService)
        {
            _context.TypeServices.Add(TypeService);
            await _context.SaveChangesAsync();
            return TypeService;
        }

        public async Task<TypeService> ChangeTypeServicesState(int Id, int newState)
        {
            var TypeService = await _context.TypeServices.FindAsync(Id);
            if (TypeService == null)
            {
                throw new Exception($"Type service with ID {Id} not found.");
            }
            TypeService.State = newState;
            await _context.SaveChangesAsync();
            return TypeService;
        }

        
    }
}
