using GestionITM.Domain.Dtos;
using GestionITM.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionITM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _service;

        public MatriculaController(IMatriculaService service)
        {
            _service = service;
        }

        // SOLO ESTUDIANTES
        [Authorize(Roles = "Estudiante")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MatriculaCreateDto dto)
        {
            await _service.RegistrarMatriculaAsync(dto);

            return Ok(new
            {
                message = "Matrícula registrada correctamente."
            });
        }
    }
}