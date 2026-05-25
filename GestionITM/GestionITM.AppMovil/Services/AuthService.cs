using System.Net.Http.Json;
using GestionITM.AppMovil.Models;

namespace GestionITM.AppMovil.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> LoginAsync()
        {
            var response =
                await _httpClient.PostAsync(
                    "http://localhost:8080/api/Auth/login",
                    null);

            if (!response.IsSuccessStatusCode)
                return false;

            var data =
                await response.Content
                .ReadFromJsonAsync<LoginResponse>();

            if (data == null)
                return false;

            await SecureStorage.SetAsync(
                "jwt_token",
                data.Token);

            return true;
        }
    }
}