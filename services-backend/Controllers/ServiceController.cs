using Microsoft.AspNetCore.Mvc;
using services_backend.DTOs;
using services_backend.Models;
using services_backend.Services;
using services_backend.Services.Interfaces;
using AutoMapper;

namespace services_backend.Controllers
{
    [Route("api/services")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServicesService _servicesService;
        private readonly ITypeServicesService _typeServicesService;
        private readonly ITimeService _timeService;
        private readonly IMapper _mapper;

        public ServiceController(IServicesService servicesService, ITypeServicesService typeServicesService, ITimeService timeService, IMapper mapper)
        {
            _servicesService = servicesService;
            _typeServicesService = typeServicesService;
            _timeService = timeService;
            _mapper = mapper;
        }

        [HttpPost("NewTypeService")]
        public async Task<IActionResult> NewTypeServices([FromBody] TypeServiceDto typeServiceDto)
        {

            try
            {
                var typeService = _mapper.Map<TypeService>(typeServiceDto);
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
        public async Task<IActionResult> NewServices([FromBody]ServiceDto serviceDto)
        {
            try
            {
                var service = _mapper.Map<Service>(serviceDto);
                var newService = await _servicesService.NewServices(service);
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

