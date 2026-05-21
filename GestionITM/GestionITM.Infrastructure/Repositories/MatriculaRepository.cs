using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionITM.Infrastructure.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        // ESTO <--- conexión con EF Core
        private readonly ApplicationDbContext _context;

        public MatriculaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // ESTO <--- crear matrícula
        public async Task<Matricula> CrearMatriculaAsync(Matricula matricula)
        {
            await _context.Matriculas.AddAsync(matricula);

            return matricula;
        }

        // ESTO <--- buscar curso
        public async Task<Curso?> ObtenerCursoPorIdAsync(int cursoId)
        {
            return await _context.Cursos
                .FirstOrDefaultAsync(c => c.Id == cursoId);
        }

        // ESTO <--- guardar cambios reales en SQL
        public async Task GuardarCambiosAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}