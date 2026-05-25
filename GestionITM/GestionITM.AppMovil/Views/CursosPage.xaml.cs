using GestionITM.AppMovil.Models;
using GestionITM.AppMovil.Services;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace GestionITM.AppMovil.Views;

public partial class CursosPage : ContentPage
{
    private readonly CursoService _cursoService;

    private int _pagina = 1;

    public ObservableCollection<Curso> Cursos { get; set; } = new();

    public CursosPage(CursoService cursoService)
    {
        InitializeComponent();

        _cursoService = cursoService;

        CursosList.ItemsSource = Cursos;

        CargarCursos();
    }

    private async void CargarCursos()
    {
        Loading.IsVisible = true;
        Loading.IsRunning = true;

        var result = await _cursoService.GetCursosAsync(_pagina);

        if (result == null)
        {
            Loading.IsVisible = false;
            Loading.IsRunning = false;
            return;
        }

        foreach (var curso in result.Items)
        {
            Cursos.Add(curso);
        }

        Loading.IsVisible = false;
        Loading.IsRunning = false;
    }

    private async void OnMatricularClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Matricula");
    }

    private void CursosList_RemainingItemsThresholdReached(object sender, EventArgs e)
    {
        _pagina++;
        CargarCursos();
    }
    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        SecureStorage.Remove("jwt_token");

        await DisplayAlert("Sesión", "Sesión cerrada", "OK");

        await Shell.Current.GoToAsync("//Login");
    }
}