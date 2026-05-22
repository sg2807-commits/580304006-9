using System.ComponentModel.DataAnnotations;

namespace GestionITM.Domain.Entities
{
    public class Curso
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Codigo { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; } = string.Empty;

        [Range(0, 30)]
        public int Creditos { get; set; }

        [Range(0, 999)]
        public int CuposDisponibles { get; set; }

        // ESTO <--- relación 1 a muchos con matrículas
        public ICollection<Matricula> Matriculas { get; set; }
            = new List<Matricula>();
    }
}