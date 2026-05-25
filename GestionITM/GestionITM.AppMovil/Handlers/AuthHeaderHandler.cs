using System.Net.Http.Headers;

namespace GestionITM.AppMovil.Handlers
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            // ESTO <--- obtener token guardado
            var token = await SecureStorage.GetAsync("jwt_token");

            // ESTO <--- si hay token, lo agregamos a la petición
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}