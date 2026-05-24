using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionITM.Infrastructure.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ApplicationDbContext _context;

        public CursoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Curso>> ObtenerTodoAsync()
        {
            return await _context.Cursos.ToListAsync();
        }

        public async Task<Curso?> ObtenerPorIdAsync(int id)
        {
            return await _context.Cursos.FindAsync(id);
        }

        public async Task AgregarAsync(Curso curso)
        {
            await _context.Cursos.AddAsync(curso);

            await _context.SaveChangesAsync();
        }

        // ESTO <--- paginación con IQueryable
        public async Task<PagedResult<Curso>> ObtenerPaginadoAsync(
            CursoFilterDto filtro)
        {
            IQueryable<Curso> query = _context.Cursos.AsQueryable();

            // ESTO <--- filtro opcional por nombre
            if (!string.IsNullOrWhiteSpace(filtro.BusquedaNombre))
            {
                query = query.Where(c =>
                    c.Nombre.Contains(filtro.BusquedaNombre));
            }

            var totalRegistros = await query.CountAsync();

            var cursos = await query
                .Skip((filtro.Pagina - 1)
                    * filtro.RegistrosPorPagina)
                .Take(filtro.RegistrosPorPagina)
                .ToListAsync();

            return new PagedResult<Curso>
            {
                Items = cursos,
                PaginaActual = filtro.Pagina,
                RegistrosPorPagina =
                    filtro.RegistrosPorPagina,
                TotalRegistros = totalRegistros,
                TotalPaginas =
                    (int)Math.Ceiling(
                        (double)totalRegistros /
                        filtro.RegistrosPorPagina)
            };
        }
    }
}