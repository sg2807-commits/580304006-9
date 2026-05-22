// ARCHIVO: MatriculaController.cs

using GestionITM.Domain.Dtos;
using GestionITM.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionITM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _matriculaService;

        public MatriculaController(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        // ============================================
        // OBTENER TODAS LAS MATRÍCULAS
        // ============================================

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatriculaDto>>> GetAll()
        {
            var matriculas = await _matriculaService.GetAllAsync();

            return Ok(matriculas);
        }

        // ============================================
        // OBTENER MATRÍCULA POR ID
        // ============================================

        [HttpGet("{id}")]
        public async Task<ActionResult<MatriculaDto>> GetById(int id)
        {
            var matricula = await _matriculaService.GetByIdAsync(id);

            if (matricula == null)
            {
                return NotFound($"No existe una matrícula con ID {id}");
            }

            return Ok(matricula);
        }

        // ============================================
        // CREAR MATRÍCULA
        // ============================================

        [HttpPost]
        public async Task<ActionResult> Create(MatriculaCreateDto dto)
        {
            try
            {
                await _matriculaService.CreateAsync(dto);

                return Ok(new
                {
                    mensaje = "Matrícula creada correctamente"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }

        // ============================================
        // ELIMINAR MATRÍCULA
        // ============================================

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var eliminado = await _matriculaService.DeleteAsync(id);

            if (!eliminado)
            {
                return NotFound($"No existe una matrícula con ID {id}");
            }

            return Ok(new
            {
                mensaje = "Matrícula eliminada correctamente"
            });
        }
    }
}