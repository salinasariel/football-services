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
        private readonly ServicesService _servicesService;

        public ReservationsService(EstablishmentService establishmentService, ClientService clientsService, ServicesService servicesService, MyDbContext context)
        {
            _establishmentService = establishmentService;
            _clientsService = clientsService;
            _context = context;
            _servicesService = servicesService;
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

       /* public async Task<Reservation> NewReservationFromEstablishment(int EstablishmentId, int Phone, Time initTime, Time finishTime, int ServiceId)
        {
            var establishment = await _establishmentService.GetEstablishmentByIdAsync(EstablishmentId);
            if (establishment == null) 
            {
                throw new Exception($"No found for Establishment ID {EstablishmentId}.");
            }
            var service = await _servicesService.GetTypeServicesById(ServiceId);
            if(service == null)
            {
                throw new Exception($"No found ServiceID {ServiceId}");
            }

            var client = await
        } */
    }
}
