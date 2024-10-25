using services_backend.Models;

namespace services_backend.Services.Interfaces
{
    public interface IReservationsService
    {
        Task<List<Reservation>> GetAllReservationsByEstablishment(int EstablishmentsId);
        Task<List<Reservation>> GetAllReservationsByService(int EstablishmentsId, int ServiceId);
        Task<Reservation> NewReservationFromEstablishment(int EstablishmentId, string Phone, DateTime initTime, DateTime finishTime, int ServiceId, string Name);
    }
}
