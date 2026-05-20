namespace GestionITM.Domain.Dtos
{
    public class CursoFilterDto
    {
        public int Pagina { get; set; } = 1;

        public int RegistrosPorPagina { get; set; } = 5;

        public string? Nombre { get; set; }
    }
}