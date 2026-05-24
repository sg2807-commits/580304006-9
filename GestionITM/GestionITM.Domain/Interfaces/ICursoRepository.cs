using GestionITM.Domain.Entities;
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Models;

namespace GestionITM.Domain.Interfaces
{
    public interface ICursoRepository
    {
        Task<IEnumerable<Curso>> ObtenerTodoAsync();

        Task<Curso?> ObtenerPorIdAsync(int id);

        Task AgregarAsync(Curso curso);

        // ESTO <--- paginación cursos
        Task<PagedResult<Curso>> ObtenerPaginadoAsync(CursoFilterDto filtro);
    }
}