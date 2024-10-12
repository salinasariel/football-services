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

        [HttpPost("new")]
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
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }
}
