using Microsoft.AspNetCore.Mvc;
using services_backend.Models;
using services_backend.Services;
using services_backend.Services.Interfaces.services_backend.Services;
using services_backend.DTOs;
using AutoMapper;


namespace services_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstablishmentController : ControllerBase
    {
        private readonly IEstablishmentService _establishmentService;
        private readonly IMapper _mapper;

        public EstablishmentController(IEstablishmentService establishmentService, IMapper mapper)
        {
            _establishmentService = establishmentService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var establishments = await _establishmentService.GetAllEstablishmentsAsync();
            return Ok(establishments);
        }

        [HttpGet("GetEstablishmetbyId")]
        public async Task<IActionResult> GetById(int id)
        {
            var establishment = await _establishmentService.GetEstablishmentByIdAsync(id);
            if (establishment == null)
                return NotFound();

            return Ok(establishment);
        }

        /*[HttpPost("CreateEstablishment")]
        public async Task<IActionResult> Create([FromBody] Establishment establishment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdEstablishment = await _establishmentService.CreateEstablishmentAsync(establishment);
            return CreatedAtAction(nameof(GetById), new { id = createdEstablishment.IdEstablishment }, createdEstablishment);
        }*/

        [HttpPost("CreateEstablishment")]
        public async Task<IActionResult> Create([FromBody] EstablishmentDto establishmentDto)
        {
            try
            {
                var establishment = _mapper.Map<Establishment>(establishmentDto);

                var createdEstablishment = await _establishmentService.CreateEstablishmentAsync(establishment);

                return Ok(createdEstablishment);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



        [HttpPut("UpdateEstablishmet")]
        public async Task<IActionResult> Update(int id, [FromBody] EstablishmentDto establishmentDto)
        {
            try
            {
            var establishment = _mapper.Map<Establishment>(establishmentDto);
            var updatedEstablishment = await _establishmentService.UpdateEstablishmentAsync(establishment);
            return Ok(updatedEstablishment);
            }
            catch
            {
                return NotFound();
            }
            
        }

        [HttpDelete("DeleteEstablishmet")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var success = await _establishmentService.DeleteEstablishmentAsync(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
           
        }
    }
}
