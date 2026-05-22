using System.ComponentModel.DataAnnotations;

namespace GestionITM.Domain.Entities
{
    public class Matricula
    {
        public int Id { get; set; }

        // ============================================
        // RELACIÓN CON ESTUDIANTE
        // ============================================

        public int EstudianteId { get; set; }

        public Estudiante? Estudiante { get; set; }

        // ============================================
        // RELACIÓN CON CURSO
        // ============================================

        public int CursoId { get; set; }

        public Curso? Curso { get; set; }

        // ============================================
        // DATOS MATRÍCULA
        // ============================================

        [Required]
        [MaxLength(20)]
        public string Periodo { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Estado { get; set; } = string.Empty;
    }
}