using GestionITM.Domain.Entities;

namespace GestionITM.Domain.Interfaces
{
    public interface IMatriculaRepository
    {
        // ESTO <--- Guarda una matrícula nueva
        Task<Matricula> CrearMatriculaAsync(Matricula matricula);

        // ESTO <--- Busca un curso por Id
        Task<Curso?> ObtenerCursoPorIdAsync(int cursoId);

        // ESTO <--- Guarda cambios en base de datos
        Task GuardarCambiosAsync();
    }
}
