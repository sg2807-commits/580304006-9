using GestionITM.AppMovil.Services;

namespace GestionITM.AppMovil.Views;

public partial class LoginPage : ContentPage
{
    private readonly AuthService _authService;

    public LoginPage(AuthService authService)
    {
        InitializeComponent();

        _authService = authService;
    }

    private async void LoginButton_Clicked(
        object sender,
        EventArgs e)
    {
        var resultado =
            await _authService.LoginAsync();

        if (resultado)
        {
            await DisplayAlert("Éxito", "Login correcto", "OK");

            // ESTO <--- navegación después del login
            await Shell.Current.GoToAsync("//Cursos");
        }
        else
        {
            await DisplayAlert(
                "Error",
                "No se pudo iniciar sesión.",
                "OK");
        }
    }
}