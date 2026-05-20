using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;

namespace GestionITM.Infrastructure.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly ApplicationDbContext _context;

        public MatriculaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AgregarAsync(Matricula matricula)
        {
            await _context.Matriculas.AddAsync(matricula);
            await _context.SaveChangesAsync();
        }
    }
}