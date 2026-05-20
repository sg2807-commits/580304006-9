using GestionITM.Domain.Dtos;

namespace GestionITM.Domain.Interfaces
{
    public interface IMatriculaService
    {
        Task RegistrarMatriculaAsync(MatriculaCreateDto dto);
    }
}