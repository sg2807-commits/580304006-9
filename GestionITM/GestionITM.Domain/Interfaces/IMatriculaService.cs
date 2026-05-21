using GestionITM.Domain.Dtos;

namespace GestionITM.Domain.Interfaces
{
    public interface IMatriculaService
    {
        // ESTO <--- Regla de negocio de matrícula
        Task<MatriculaDto> CrearMatriculaAsync(MatriculaCreateDto matriculaDto);
    }
}