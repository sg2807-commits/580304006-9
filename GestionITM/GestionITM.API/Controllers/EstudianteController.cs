// ESTUDIANTECONTROLLER.CS

using Microsoft.AspNetCore.Mvc;
using GestionITM.Domain.Interfaces;
using GestionITM.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace GestionITM.API.Controllers
{
    // ESTO <--- quitamos el candado global temporalmente
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteService _service;

        public EstudianteController(IEstudianteService service)
        {
            _service = service;
        }

        // GET: api/estudiante
        [Authorize] // ESTO <--- protegemos solo este endpoint
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstudianteDto>>> Get()
        {
            var estudiantesDto = await _service.ObtenerTodosLosEstudiantesAsync();

            return Ok(estudiantesDto);
        }

        // GET: api/estudiante/5
        [Authorize] // ESTO <--- protegemos solo este endpoint
        [HttpGet("{id:int}")]
        public async Task<ActionResult<EstudianteDto>> Get(int id)
        {
            var estudianteDto = await _service.ObtenerPorIdAsync(id);

            if (estudianteDto == null)
            {
                return NotFound(new
                {
                    message = $"Estudiante con ID {id} no encontrado."
                });
            }

            return Ok(estudianteDto);
        }

        // POST: api/estudiante
        [AllowAnonymous] // ESTO <--- dejamos crear estudiantes sin token
        [HttpPost]
        public async Task<ActionResult> Post(
            [FromBody] EstudianteCreateDto estudianteCreateDto)
        {
            var resultado = await _service
                .RegistrarEstudianteAsync(estudianteCreateDto);

            if (!resultado)
            {
                return BadRequest(
                    "No se pudo registrar. Verifique que el correo sea institucional (@correo.itm.edu.co).");
            }

            return Ok(new
            {
                message = "Estudiante registrado con éxito en el sistema del ITM."
            });
        }
    }
}