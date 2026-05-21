// ARCHIVO: MatriculaService.cs

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

        // ============================================
        // OBTENER TODAS LAS MATRÍCULAS
        // ============================================

        public async Task<IEnumerable<MatriculaDto>> GetAllAsync()
        {
            var matriculas = await _matriculaRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<MatriculaDto>>(matriculas);
        }

        // ============================================
        // OBTENER MATRÍCULA POR ID
        // ============================================

        public async Task<MatriculaDto?> GetByIdAsync(int id)
        {
            var matricula = await _matriculaRepository.GetByIdAsync(id);

            if (matricula == null)
            {
                return null;
            }

            return _mapper.Map<MatriculaDto>(matricula);
        }

        // ============================================
        // CREAR MATRÍCULA
        // ============================================

        public async Task CreateAsync(MatriculaCreateDto matriculaDto)
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

            await _matriculaRepository.CreateAsync(matricula);

            await _matriculaRepository.GuardarCambiosAsync();
        }

        // ============================================
        // ELIMINAR MATRÍCULA
        // ============================================

        public async Task<bool> DeleteAsync(int id)
        {
            var matricula = await _matriculaRepository.GetByIdAsync(id);

            if (matricula == null)
            {
                return false;
            }

            await _matriculaRepository.DeleteAsync(matricula);

            await _matriculaRepository.GuardarCambiosAsync();

            return true;
        }
    }
}