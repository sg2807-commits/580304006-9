using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;
using GestionITM.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionITM.Infrastructure.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _repository;

        public CursoService(ICursoRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<Curso>> ObtenerPaginadosAsync(CursoFilterDto filtro)
        {
            var consulta = _repository.ConsultarTodo();

            if (!string.IsNullOrWhiteSpace(filtro.Nombre))
            {
                consulta = consulta.Where(c =>
                    c.Nombre.Contains(filtro.Nombre));
            }

            var totalRegistros = await consulta.CountAsync();

            var items = await consulta
                .Skip((filtro.Pagina - 1) * filtro.RegistrosPorPagina)
                .Take(filtro.RegistrosPorPagina)
                .ToListAsync();

            return new PagedResult<Curso>
            {
                Items = items,
                PaginaActual = filtro.Pagina,
                RegistrosPorPagina = filtro.RegistrosPorPagina,
                TotalRegistros = totalRegistros,
                TotalPaginas = (int)Math.Ceiling(
                    totalRegistros / (double)filtro.RegistrosPorPagina)
            };
        }
    }
}
