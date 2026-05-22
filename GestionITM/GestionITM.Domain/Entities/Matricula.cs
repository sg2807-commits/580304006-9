using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionITM.Domain.Entities
{
    public class Matricula
    {
        public int Id { get; set; }

        // ESTO <--- llave foránea estudiante
        public int EstudianteId { get; set; }

        // ESTO <--- navegación estudiante
        [ForeignKey("EstudianteId")]
        public Estudiante? Estudiante { get; set; }

        // ESTO <--- llave foránea curso
        public int CursoId { get; set; }

        // ESTO <--- navegación curso
        [ForeignKey("CursoId")]
        public Curso? Curso { get; set; }

        [Required]
        [MaxLength(20)]
        public string Periodo { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Estado { get; set; } = string.Empty;
    }
}