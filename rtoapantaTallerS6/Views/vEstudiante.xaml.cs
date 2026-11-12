using Newtonsoft.Json;
using rtoapantaTallerS6.Models;
using System.Collections.ObjectModel;

namespace rtoapantaTallerS6;

public partial class vEstudiante : ContentPage
{
    private const string Url = "http://192.168.17.23:8088/ws_uisrael/ws_estudiante.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Estudiante> _estudiantes;
    public vEstudiante()
	{
		InitializeComponent();
        cargarEstudiantes();

    }

    private async void cargarEstudiantes()
    {
        try
        {
            var contenido = await cliente.GetStringAsync(Url);
            var estudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(contenido);
            _estudiantes = new ObservableCollection<Estudiante>(estudiantes);
            lvEstudiantes.ItemsSource = _estudiantes;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private void lvEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.vNuevoEstudiante());
    }
}