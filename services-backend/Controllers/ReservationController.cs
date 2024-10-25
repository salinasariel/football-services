using Microsoft.AspNetCore.Mvc;
using services_backend.Models;
using services_backend.Services.Interfaces;

namespace services_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationsService _reservationsService;

        public ReservationController(IReservationsService reservationsService)
        {
            _reservationsService = reservationsService;
        }

        [HttpGet("GetAllReservationsByEstablishment")]
        public async  Task<IActionResult> GetAllReservationsByEstablishment(int EstablishmentsId)
        {
            try
            {
                var reservations = await _reservationsService.GetAllReservationsByEstablishment(EstablishmentsId);
                return Ok(reservations);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        [HttpGet("GetAllReservationsByService")]
        public async Task<IActionResult> GetAllReservationsByService(int EstablishmentsId, int ServiceId)
        {
            try
            {
                var reservations = await _reservationsService.GetAllReservationsByService(EstablishmentsId, ServiceId);
                return Ok(reservations);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        [HttpPost("NewReservation")]
        public async Task<IActionResult> NewReservationFromEstablishment(int EstablishmentId, string Phone, DateTime initTime, DateTime finishTime, int ServiceId, string Name)
        {           

            try
            {
                var newReservation = await _reservationsService.NewReservationFromEstablishment(
                    EstablishmentId,
                    Phone,
                    initTime,
                    finishTime,
                    ServiceId,
                    Name
                );

                return Ok(newReservation);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

    }
}
