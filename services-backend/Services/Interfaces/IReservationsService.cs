using services_backend.Models;

namespace services_backend.Services.Interfaces
{
    public interface IReservationsService
    {
        Task<List<Reservation>> GetAllReservationsByEstablishment(int EstablishmentsId);
    }
}
