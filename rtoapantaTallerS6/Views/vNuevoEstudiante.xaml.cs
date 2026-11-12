using System.Net;

namespace rtoapantaTallerS6.Views;

public partial class vNuevoEstudiante : ContentPage
{
    private const string Url = "http://192.168.17.23:8088/ws_uisrael/ws_estudiante.php";
    public vNuevoEstudiante()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
			parametros.Add("apellido", txtApellido.Text);
			parametros.Add("edad", txtEdad.Text);
			cliente.UploadValues(Url, "POST", parametros);
			Navigation.PushAsync(new vEstudiante());
		}catch(Exception ex)
		{
            DisplayAlert("Error crear estudiante", ex.Message, "OK");
        }
    }
}