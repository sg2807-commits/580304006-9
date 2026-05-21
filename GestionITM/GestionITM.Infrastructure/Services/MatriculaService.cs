using AutoMapper;
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;

namespace GestionITM.Infrastructure.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _matriculaRepository;
        private readonly IMapper _mapper;

        public MatriculaService(
            IMatriculaRepository matriculaRepository,
            IMapper mapper)
        {
            _matriculaRepository = matriculaRepository;
            _mapper = mapper;
        }

        public async Task<MatriculaDto> CrearMatriculaAsync(MatriculaCreateDto matriculaDto)
        {
            // ESTO <--- buscamos el curso
            var curso = await _matriculaRepository
                .ObtenerCursoPorIdAsync(matriculaDto.CursoId);

            // ESTO <--- validamos si existe
            if (curso == null)
            {
                throw new Exception("El curso no existe.");
            }

            // ESTO <--- regla de negocio de la rúbrica
            if (curso.CuposDisponibles <= 0)
            {
                throw new Exception("No hay cupos disponibles para este curso.");
            }

            // ESTO <--- restar cupo disponible
            curso.CuposDisponibles--;

            // ESTO <--- crear entidad
            var matricula = new Matricula
            {
                EstudianteId = matriculaDto.EstudianteId,
                CursoId = matriculaDto.CursoId,
                Periodo = matriculaDto.Periodo,

                // ESTO <--- matrícula activa por defecto
                Estado = "Activa"
            };

            await _matriculaRepository.CrearMatriculaAsync(matricula);

            await _matriculaRepository.GuardarCambiosAsync();

            return _mapper.Map<MatriculaDto>(matricula);
        }
    }
}