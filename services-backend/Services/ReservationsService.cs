using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using MySqlX.XDevAPI;
using services_backend.Models;
using services_backend.Services.Interfaces;
using services_backend.Services.Interfaces.services_backend.Services;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace services_backend.Services
{
    public class ReservationsService : IReservationsService
    {
        private readonly MyDbContext _context;
        private readonly IClientService _clientsService;
        private readonly IEstablishmentService _establishmentService;
        private readonly IServicesService _servicesService;

        public ReservationsService(IEstablishmentService establishmentService, IClientService clientsService, IServicesService servicesService, MyDbContext context)
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

        public async Task<List<Reservation>> GetAllReservationsByService(int EstablishmentsId, int ServiceId)
        {
            var reservations = await _context.Reservations
                .Where(c => c.EstablishmentId == EstablishmentsId && c.ServiceId == ServiceId)
                .ToListAsync();
            if (reservations == null || reservations.Count == 0)
            {
                throw new Exception($"No reservations found for Establishment ID {EstablishmentsId} OR service ID {ServiceId}.");
            }

            return reservations;
        }

        public async Task<Reservation> NewReservationFromEstablishment(int EstablishmentId, string Phone, DateTime initTime, DateTime finishTime, int ServiceId, string Name)
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
            
            /*
             
            ACA TENGO QUE HACER UNA VERIFIACION SI ESTA RESERVADO EN ESE HORARIO SERVICIO ESTABLECIMIENTO: PARA QUE NO ME RESERVEN DOS A LA VEZ
             
             */

            var exitsClient = await _clientsService.GetClientByPhone(Phone);
            Client clientToUse;
            if (exitsClient == null)
            {
                var newClient = new Client
                {
                    Phone = Phone,
                    Name = Name,
                    Email = "user@user.com",
                    State = 1,
                    Ban = 0,
                    EstablishmentId = EstablishmentId
                };
                await _clientsService.NewClient(newClient);
                clientToUse = newClient;
            } else
            {
                clientToUse = exitsClient;
            }
            // else if (exitsClient != null) 
            // {
            var newReservation = new Reservation
            {
                EstablishmentId = EstablishmentId,
                ClientId = clientToUse.IdClients,  
                ServiceId = ServiceId,
                Day = DateTime.Now,         
                InitTime = initTime,        
                FinishTime = finishTime,   
                Cancel = 0                   
            };

            _context.Reservations.Add(newReservation);
            await _context.SaveChangesAsync();
            // }
            return newReservation;
        } 
    }
}
