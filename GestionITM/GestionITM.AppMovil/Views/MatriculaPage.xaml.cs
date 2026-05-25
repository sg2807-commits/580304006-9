using GestionITM.AppMovil.Services;
using GestionITM.AppMovil.Models;
using GestionITM.AppMovil.Models;

namespace GestionITM.AppMovil.Views;

public partial class MatriculaPage : ContentPage
{
    private readonly MatriculaService _service;

    public MatriculaPage(MatriculaService service)
    {
        InitializeComponent();
        _service = service;
    }

    private async void OnMatricularClicked(object sender, EventArgs e)
    {
        if (!int.TryParse(CursoIdEntry.Text, out int cursoId))
        {
            await DisplayAlert("Error", "ID inválido", "OK");
            return;
        }

        var dto = new MatriculaCreate
        {
            EstudianteId = 1, // simulado (luego lo sacamos del token si quieres nivel pro)
            CursoId = cursoId,
            Periodo = "2026-1"
        };

        var result = await _service.CrearMatriculaAsync(dto);

        if (result.ok)
        {
            await DisplayAlert("Éxito", result.mensaje, "OK");
        }
        else
        {
            // 🔥 UX BONITA: en vez de crashear, mostramos mensaje limpio
            await DisplayAlert("No se pudo matricular", result.mensaje.Replace("{", "").Replace("}", ""), "OK");
        }
    }
}