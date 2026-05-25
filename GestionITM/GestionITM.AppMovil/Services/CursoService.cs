using System.Net.Http.Json;
using GestionITM.AppMovil.Models;

namespace GestionITM.AppMovil.Services
{
    public class CursoService
    {
        private readonly HttpClient _httpClient;

        public CursoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PagedResult<Curso>?> GetCursosAsync(int pagina)
        {
            return await _httpClient.GetFromJsonAsync<PagedResult<Curso>>(
                $"api/Curso/paginado?Pagina={pagina}&RegistrosPorPagina=5");
        }
    }
}