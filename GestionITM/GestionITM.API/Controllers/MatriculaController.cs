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
        // ESTO <--- inyección del servicio
        private readonly IMatriculaService _matriculaService;

        public MatriculaController(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        // ESTO <--- obtener todas las matrículas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatriculaDto>>> Get()
        {
            var matriculas = await _matriculaService.GetAllAsync();

            return Ok(matriculas);
        }

        // ESTO <--- obtener matrícula por id
        [HttpGet("{id}")]
        public async Task<ActionResult<MatriculaDto>> GetById(int id)
        {
            var matricula = await _matriculaService.GetByIdAsync(id);

            if (matricula == null)
            {
                return NotFound(new
                {
                    message = "Matrícula no encontrada."
                });
            }

            return Ok(matricula);
        }

        // ESTO <--- crear matrícula
        [Authorize(Roles = "Estudiante")]
        [HttpPost]
        public async Task<ActionResult> Post(MatriculaCreateDto matriculaDto)
        {
            try
            {
                await _matriculaService.CreateAsync(matriculaDto);

                return Ok(new
                {
                    message = "Matrícula creada correctamente."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }

        // ESTO <--- eliminar matrícula
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var eliminado = await _matriculaService.DeleteAsync(id);

            if (!eliminado)
            {
                return NotFound(new
                {
                    message = "Matrícula no encontrada."
                });
            }

            return Ok(new
            {
                message = "Matrícula eliminada correctamente."
            });
        }
    }
}