using Microsoft.AspNetCore.Mvc;
using services_backend.Models;
using services_backend.Services;
using services_backend.Services.Interfaces;

namespace services_backend.Controllers
{
    public class ServiceController : ControllerBase
    {
        private readonly IServicesService _servicesService;
        private readonly ITypeServicesService _typeServicesService;

        public ServiceController(IServicesService servicesService, ITypeServicesService typeServicesService)
        {
            _servicesService = servicesService;
            _typeServicesService = typeServicesService;
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

    }

}

