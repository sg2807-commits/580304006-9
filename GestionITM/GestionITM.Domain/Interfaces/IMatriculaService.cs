// ARCHIVO: IMatriculaService.cs

using GestionITM.Domain.Dtos;

namespace GestionITM.Domain.Interfaces
{
    public interface IMatriculaService
    {
        // ============================================
        // OBTENER TODAS LAS MATRÍCULAS
        // ============================================

        Task<IEnumerable<MatriculaDto>> GetAllAsync();

        // ============================================
        // OBTENER MATRÍCULA POR ID
        // ============================================

        Task<MatriculaDto?> GetByIdAsync(int id);

        // ============================================
        // CREAR MATRÍCULA
        // ============================================

        Task CreateAsync(MatriculaCreateDto dto);

        // ============================================
        // ELIMINAR MATRÍCULA
        // ============================================

        Task<bool> DeleteAsync(int id);
    }
}