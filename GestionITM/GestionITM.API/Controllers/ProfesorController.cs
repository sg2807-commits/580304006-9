using GestionITM.API.DTOs;
using GestionITM.Domain.Dtos; 
using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionITM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesorService _profesorService; // Acceso al servicio

        public ProfesorController(IProfesorService profesorService)
        {
            _profesorService = profesorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfesorDto>>> Get()
        {
            var profesores = await _profesorService.GetAllAsync();

            var resultado = profesores.Select(p => new ProfesorDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Especialidad = p.Especialidad,
                Email = p.Email
            });

            return Ok(resultado);
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<ProfesorDto>> GetById(int id)
        {
            var profesor = await _profesorService.GetByIdAsync(id);
            if (profesor == null)
                return NotFound();

            var dto = new ProfesorDto
            {
                Id = profesor.Id,
                Nombre = profesor.Nombre,
                Especialidad = profesor.Especialidad,
                Email = profesor.Email
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProfesorCreateDto dto)
        {
            var profesor = new Profesor
            {
                Nombre = dto.Nombre,
                Especialidad = dto.Especialidad,
                Email = dto.Email,
                FechaContratacion = System.DateTime.Now
            };

            await _profesorService.AddAsync(profesor);

            return Ok("Profesor creado correctamente");
        }
    }
}