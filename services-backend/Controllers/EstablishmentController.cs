using Microsoft.AspNetCore.Mvc;
using services_backend.Models;
using services_backend.Services;
using services_backend.Services.Interfaces.services_backend.Services;

namespace services_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstablishmentController : ControllerBase
    {
        private readonly IEstablishmentService _establishmentService;

        public EstablishmentController(IEstablishmentService establishmentService)
        {
            _establishmentService = establishmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var establishments = await _establishmentService.GetAllEstablishmentsAsync();
            return Ok(establishments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var establishment = await _establishmentService.GetEstablishmentByIdAsync(id);
            if (establishment == null)
                return NotFound();

            return Ok(establishment);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Establishment establishment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdEstablishment = await _establishmentService.CreateEstablishmentAsync(establishment);
            return CreatedAtAction(nameof(GetById), new { id = createdEstablishment.IdEstablishment }, createdEstablishment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Establishment establishment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != establishment.IdEstablishment)
                return BadRequest("El ID del establecimiento no coincide.");

            var updatedEstablishment = await _establishmentService.UpdateEstablishmentAsync(establishment);
            return Ok(updatedEstablishment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _establishmentService.DeleteEstablishmentAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
