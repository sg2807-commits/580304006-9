using System.Net.Http.Json;
using GestionITM.AppMovil.Models;

namespace GestionITM.AppMovil.Services
{
    public class MatriculaService
    {
        private readonly HttpClient _httpClient;

        public MatriculaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<(bool ok, string mensaje)> CrearMatriculaAsync(MatriculaCreate dto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Matricula", dto);

                if (response.IsSuccessStatusCode)
                {
                    return (true, "Matrícula creada correctamente");
                }

                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}