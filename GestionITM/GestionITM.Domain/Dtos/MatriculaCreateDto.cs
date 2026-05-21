using System.ComponentModel.DataAnnotations;

namespace GestionITM.Domain.Dtos
{
    public class MatriculaCreateDto
    {
        // ESTO <--- Id del estudiante que se va a matricular
        [Required]
        public int EstudianteId { get; set; }

        // ESTO <--- Curso al que quiere entrar
        [Required]
        public int CursoId { get; set; }

        // ESTO <--- Ejemplo: 2026-1
        [Required]
        [MaxLength(20)]
        public string Periodo { get; set; } = string.Empty;
    }
}