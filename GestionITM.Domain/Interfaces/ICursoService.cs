using System.Threading.Tasks;
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;
using GestionITM.Domain.Models;

namespace GestionITM.Domain.Interfaces
{
    public interface ICursoService
    {
        Task<PagedResult<Curso>> ObtenerPaginadosAsync(CursoFilterDto filtro);
    }
}