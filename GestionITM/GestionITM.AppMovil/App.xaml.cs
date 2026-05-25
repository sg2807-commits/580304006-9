using GestionITM.AppMovil.Views;

namespace GestionITM.AppMovil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // ESTO <--- decide flujo inicial
            _ = CheckLoginAsync();
        }

        private async Task CheckLoginAsync()
        {
            var token = await SecureStorage.GetAsync("jwt_token");

            MainPage = string.IsNullOrEmpty(token)
                ? new AppShell() // login
                : new AppShell(); // cursos directo (lo mejor es Shell lo maneja)
        }
    }
}