namespace GestionITM.Domain.Models
{
    // CONTENEDOR GENÉRICO PARA PAGINACIÓN
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new();

        public int PaginaActual { get; set; }

        public int TotalPaginas { get; set; }

        public int TotalRegistros { get; set; }

        public int RegistrosPorPagina { get; set; }
    }
}
