namespace GestionITM.Domain.Dtos
{
    public class CursoFilterDto
    {
        public int Pagina { get; set; } = 1;

        public int RegistrosPorPagina { get; set; } = 10;

        public string? BusquedaNombre { get; set; }
    }
}