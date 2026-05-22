// ARCHIVO: IMatriculaRepository.cs

using GestionITM.Domain.Entities;

namespace GestionITM.Domain.Interfaces
{
    public interface IMatriculaRepository
    {
        // ============================================
        // OBTENER TODAS LAS MATRÍCULAS
        // ============================================

        Task<IEnumerable<Matricula>> GetAllAsync();

        // ============================================
        // OBTENER MATRÍCULA POR ID
        // ============================================

        Task<Matricula?> GetByIdAsync(int id);

        // ============================================
        // CREAR MATRÍCULA
        // ============================================

        Task CreateAsync(Matricula matricula);

        // ============================================
        // ELIMINAR MATRÍCULA
        // ============================================

        Task DeleteAsync(Matricula matricula);

        // ============================================
        // GUARDAR CAMBIOS
        // ============================================

        Task GuardarCambiosAsync();

        // ============================================
        // OBTENER CURSO
        // ============================================

        Task<Curso?> ObtenerCursoPorIdAsync(int cursoId);

        // ============================================
        // OBTENER ESTUDIANTE
        // ============================================

        Task<Estudiante?> ObtenerEstudiantePorIdAsync(int estudianteId);

        // ============================================
        // MATRÍCULA EXISTENTE
        // ============================================

        Task<bool> ExisteMatriculaAsync(int estudianteId, int cursoId);
    }
}
