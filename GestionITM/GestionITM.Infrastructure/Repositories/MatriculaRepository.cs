// ARCHIVO: MatriculaRepository.cs

using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionITM.Infrastructure.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly ApplicationDbContext _context;

        public MatriculaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // ============================================
        // OBTENER TODAS LAS MATRÍCULAS
        // ============================================

        public async Task<IEnumerable<Matricula>> GetAllAsync()
        {
            return await _context.Matriculas
                .Include(m => m.Estudiante)
                .Include(m => m.Curso)
                .ToListAsync();
        }

        // ============================================
        // OBTENER POR ID
        // ============================================

        public async Task<Matricula?> GetByIdAsync(int id)
        {
            return await _context.Matriculas
                .Include(m => m.Estudiante)
                .Include(m => m.Curso)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        // ============================================
        // CREAR MATRÍCULA
        // ============================================

        public async Task CreateAsync(Matricula matricula)
        {
            await _context.Matriculas.AddAsync(matricula);
        }

        // ============================================
        // ELIMINAR MATRÍCULA
        // ============================================

        public async Task DeleteAsync(Matricula matricula)
        {
            _context.Matriculas.Remove(matricula);

            await Task.CompletedTask;
        }

        // ============================================
        // GUARDAR CAMBIOS
        // ============================================

        public async Task GuardarCambiosAsync()
        {
            await _context.SaveChangesAsync();
        }

        // ============================================
        // OBTENER CURSO
        // ============================================

        public async Task<Curso?> ObtenerCursoPorIdAsync(int cursoId)
        {
            return await _context.Cursos
                .FirstOrDefaultAsync(c => c.Id == cursoId);
        }

        // ============================================
        // OBTENER ESTUDIANTE
        // ============================================

        public async Task<Estudiante?> ObtenerEstudiantePorIdAsync(int estudianteId)
        {
            return await _context.Estudiantes
                .FirstOrDefaultAsync(e => e.Id == estudianteId);
        }

        // ============================================
        // MATRÍCULA EXISTENTE
        // ============================================

        public async Task<bool> ExisteMatriculaAsync(int estudianteId, int cursoId)
        {
            return await _context.Matriculas
                .AnyAsync(m =>
                    m.EstudianteId == estudianteId &&
                    m.CursoId == cursoId);
        }
    }
}