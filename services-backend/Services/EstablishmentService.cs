using Microsoft.EntityFrameworkCore;
using services_backend.Models;
using services_backend.Services.Interfaces.services_backend.Services;

namespace services_backend.Services
{
    public class EstablishmentService : IEstablishmentService
    {
        private readonly MyDbContext _context;

        public EstablishmentService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Establishment> CreateEstablishmentAsync(Establishment establishment)
        {
            _context.Establishments.Add(establishment);
            await _context.SaveChangesAsync();
            return establishment;
        }

        public async Task<List<Establishment>> GetAllEstablishmentsAsync()
        {
            return await _context.Establishments.ToListAsync();
        }

        public async Task<Establishment> GetEstablishmentByIdAsync(int id)
        {
            return await _context.Establishments.FindAsync(id);
        }

        public async Task<bool> DeleteEstablishmentAsync(int id)
        {
            var establishment = await _context.Establishments.FindAsync(id);
            if (establishment == null) return false;

            _context.Establishments.Remove(establishment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Establishment> UpdateEstablishmentAsync(Establishment establishment)
        {
            _context.Entry(establishment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return establishment;
        }
    }
}
