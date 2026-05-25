using GestionITM.AppMovil.Handlers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using GestionITM.AppMovil.Services;
using GestionITM.AppMovil.Views;

namespace GestionITM.AppMovil
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont(
                        "OpenSans-Regular.ttf",
                        "OpenSansRegular");

                    fonts.AddFont(
                        "OpenSans-Semibold.ttf",
                        "OpenSansSemibold");
                });


            // ESTO <--- registrar HttpClient
            builder.Services.AddHttpClient<AuthService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<LoginPage>();

            builder.Services.AddTransient<AuthHeaderHandler>();

            builder.Services.AddHttpClient<AuthService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:8080/");
            })
            .AddHttpMessageHandler<AuthHeaderHandler>();

            builder.Services.AddHttpClient<CursoService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:8080/");
            })
            .AddHttpMessageHandler<AuthHeaderHandler>();

            builder.Services.AddTransient<CursosPage>();

            builder.Services.AddHttpClient<MatriculaService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:8080/");
            })
            .AddHttpMessageHandler<AuthHeaderHandler>();

            builder.Services.AddTransient<MatriculaPage>();
            builder.Services.AddHttpClient<MatriculaService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:8080/");
            })
            .AddHttpMessageHandler<AuthHeaderHandler>();

            return builder.Build();
        }
    }
}