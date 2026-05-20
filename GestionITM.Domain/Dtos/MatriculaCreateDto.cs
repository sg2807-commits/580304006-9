namespace GestionITM.Domain.Dtos
{
    public class MatriculaCreateDto
    {
        public int EstudianteId { get; set; }

        public int CursoId { get; set; }

        public string Periodo { get; set; } = string.Empty;
    }
}