using AutoMapper;
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;

namespace GestionITM.Infrastructure.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _repository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IMapper _mapper;

        public MatriculaService(
            IMatriculaRepository repository,
            ICursoRepository cursoRepository,
            IMapper mapper)
        {
            _repository = repository;
            _cursoRepository = cursoRepository;
            _mapper = mapper;
        }

        public async Task RegistrarMatriculaAsync(MatriculaCreateDto dto)
        {
            var curso = await _cursoRepository.ObtenerPorIdAsync(dto.CursoId);

            // ESTO <--- REGLA DE NEGOCIO
            if (curso == null)
            {
                throw new Exception("Curso no encontrado.");
            }

            // ESTO <--- REGLA DE NEGOCIO
            if (curso.CuposDisponibles <= 0)
            {
                throw new ArgumentException("No hay cupos disponibles para este curso.");
            }

            // ESTO <--- DESCONTAR CUPO
            curso.CuposDisponibles--;

            var matricula = _mapper.Map<Matricula>(dto);

            matricula.Estado = "Activa";

            await _repository.AgregarAsync(matricula);
        }
    }
}