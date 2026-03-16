// Acá no puede ir fecha de contratación (este es solo de lectura):

namespace GestionITM.API.DTOs
{
    public class ProfesorDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Especialidad { get; set; }

        public string Email { get; set; }
    }
}