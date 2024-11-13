using Microsoft.AspNetCore.Mvc;
using services_backend.Models;
using services_backend.Services;
using services_backend.Services.Interfaces;

namespace services_backend.Controllers
{
    [Route("api/services")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServicesService _servicesService;
        private readonly ITypeServicesService _typeServicesService;
        private readonly ITimeService _timeService;

        public ServiceController(IServicesService servicesService, ITypeServicesService typeServicesService, ITimeService timeService)
        {
            _servicesService = servicesService;
            _typeServicesService = typeServicesService;
            _timeService = timeService;
        }

        [HttpPost("NewTypeService")]
        public async Task<IActionResult> NewTypeServices([FromBody] TypeService typeService)
        {

            try
            {
                var newTypeService = await _typeServicesService.NewTypeServices(typeService);

                return Ok(newTypeService);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        [HttpGet("GetActiveAllTypeServicesByEstablishment")]
        public async Task<IActionResult> GetActiveAllTypeServicesByEstablishment(int EstablishmentID)
        {
            try
            {
                var typeServices = await _typeServicesService.GetActiveAllTypeServicesByEstablishment(EstablishmentID);
                return Ok(typeServices);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }
        [HttpPost("NewService")]
        public async Task<IActionResult> NewServices([FromBody]Service Service)
        {
            try
            {
                var service = await _servicesService.NewServices(Service);
                return Ok(service);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        [HttpPost("NewFranjaTimes")]
        public async Task<IActionResult> NewFranjaTimes(int ServiceId, int Day, DateTime firstTime, DateTime finishTime)
        {
            await _timeService.NewFranjaTimes(ServiceId, Day, firstTime, finishTime);
            return Ok();
        }

    }

}

