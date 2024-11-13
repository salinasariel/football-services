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
        // Mapeo de DTO a modelo
        var establishment = _mapper.Map<Establishment>(establishmentDto);

        // Llamada al servicio para crear el establecimiento
        var createdEstablishment = await _establishmentService.CreateEstablishmentAsync(establishment);

        // Retorno exitoso con el objeto creado
        return CreatedAtAction(nameof(GetById), new { id = createdEstablishment.IdEstablishment }, createdEstablishment);
    }
    catch (Exception ex)
    {
        // Manejo de errores si ocurre algo
        return BadRequest(new { message = ex.Message });
    }
}



        [HttpPut("UpdateEstablishmet")]
        public async Task<IActionResult> Update(int id, [FromBody] Establishment establishment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != establishment.IdEstablishment)
                return BadRequest("El ID del establecimiento no coincide.");

            var updatedEstablishment = await _establishmentService.UpdateEstablishmentAsync(establishment);
            return Ok(updatedEstablishment);
        }

        [HttpDelete("DeleteEstablishmet")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _establishmentService.DeleteEstablishmentAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
