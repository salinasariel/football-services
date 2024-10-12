using Microsoft.EntityFrameworkCore;
using services_backend.Models;
using services_backend.Services.Interfaces;

namespace services_backend.Services
{
    public class TypeServicesService : ITypeServicesService
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

        public async Task<List<TypeService>> GetActiveAllTypeServicesByEstablishment(int EstablishmentID)
        {
            try
            {
                var services = await _context.TypeServices.Where(c => c.Active == 1 && c.State == 1 && c.EstablishmentId == EstablishmentID).ToListAsync();
            if (services == (null)) 
            {
                throw new Exception($"No found Type Services por Establishment ID {EstablishmentID}");
            }
                return services; 
            }
            catch (Exception ex)
            {
                throw new Exception($"Service NewTypeServices failed: {ex.Message}", ex);
            }
        }

        public async Task<TypeService> NewTypeServices(TypeService typeService)
        {
            try
            {
                _context.TypeServices.Add(typeService);
                await _context.SaveChangesAsync();
                return typeService;
            }
            catch (Exception ex)
            {
                throw new Exception($"Service NewTypeServices failed: {ex.Message}", ex);
            }
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
