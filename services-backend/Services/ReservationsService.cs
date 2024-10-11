using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using services_backend.Models;
using services_backend.Services.Interfaces;

namespace services_backend.Services
{
    public class ReservationsService : IReservationsService
    {
        private readonly MyDbContext _context;

        private readonly ClientService _clientsService;

        private readonly EstablishmentService _establishmentService;

        public ReservationsService(EstablishmentService establishmentService, ClientService clientsService, MyDbContext context)
        {
            _establishmentService = establishmentService;
            _clientsService = clientsService;
            _context = context;
        }

        public async Task<List<Reservation>> GetAllReservationsByEstablishment(int EstablishmentsId)
        {
            var reservations = await _context.Reservations
                .Where(c => c.EstablishmentId == EstablishmentsId)
                .ToListAsync();
            if (reservations == null || reservations.Count == 0)
            {
                throw new Exception($"No reservations found for Establishment ID {EstablishmentsId}.");
            }

            return reservations;
        }

        /*public async Task<Reservation> NewReservationFromEstablishment(int EstablishmentId, int Phone, Time initTime, Time finishTime, int ServiceId)
        {
            var establishmet = GetEstablishmentByIdAsync(EstablishmentId);
        }*/
    }
}
