using Microsoft.AspNetCore.Mvc;
using SMI.Shared.DTOs;
using Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaDTO>>> GetAll()
        {
            var personas = await _personaService.GetAllPersonasAsync();
            return Ok(personas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaDTO>> GetById(int id)
        {
            var persona = await _personaService.GetPersonaByIdAsync(id);
            if (persona == null)
                return NotFound();

            return Ok(persona);
        }

        [HttpPost]
        public async Task<ActionResult<PersonaDTO>> Create([FromBody] PersonaDTO personaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdPersona = await _personaService.AddPersonaAsync(personaDto);
            return CreatedAtAction(nameof(GetById), new { id = createdPersona.id }, createdPersona);
        }

        // Update ahora recibe solo el DTO con Id incluido
        [HttpPut("{id}")]
        public async Task<ActionResult<PersonaDTO>> Update(int id, [FromBody] PersonaDTO personaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (personaDto.id == null || personaDto.id != id)
                return BadRequest("El Id en el cuerpo y la URL no coinciden");

            var updatedPersona = await _personaService.UpdatePersonaAsync(personaDto);
            if (updatedPersona == null)
                return NotFound();

            return Ok(updatedPersona);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _personaService.DeletePersonaAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
