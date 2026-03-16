using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace GestionITM.Domain.Entities
{
    public class Profesor
    {
        public int Id { get; set; }

        [Required] // Indica que el campo es obligatorio
        [MaxLength(100)] // De máximo 100 caracteres
        public string Nombre { get; set; }

        public string Especialidad { get; set; }

        [Required] // Obligatorio
        public string Email { get; set; }

        public DateTime FechaContratacion { get; set; }
    }
}
