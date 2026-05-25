namespace GestionITM.AppMovil.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int Creditos { get; set; }
        public int CuposDisponibles { get; set; }
    }
}
