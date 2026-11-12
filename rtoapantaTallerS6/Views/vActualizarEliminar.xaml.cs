using rtoapantaTallerS6.Models;
using System.Net;
using System.Collections.Specialized;

namespace rtoapantaTallerS6.Views;

public partial class vActualizarEliminar : ContentPage
{
    private const string Url = "http://192.168.17.23:8088/ws_uisrael/ws_estudiante.php";

	public vActualizarEliminar()
	{
		InitializeComponent();
	}

    public vActualizarEliminar(Estudiante estudiante)
    {
        InitializeComponent();
        txtCodigo.Text = estudiante.codigo.ToString();
        txtNombre.Text = estudiante.nombre.ToString();
        txtApellido.Text = estudiante.apellido.ToString();
        txtEdad.Text = estudiante.edad.ToString();
    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        bool confirmar = await DisplayAlert(
            "Confirmar actualización",
            "¿Desea actualizar los datos del estudiante?",
            "Sí", "No");

        if (!confirmar)
            return;

        if (!int.TryParse(txtCodigo.Text, out int codigo) ||
            string.IsNullOrWhiteSpace(txtNombre.Text) ||
            string.IsNullOrWhiteSpace(txtApellido.Text) ||
            !int.TryParse(txtEdad.Text, out int edad))
        {
            await DisplayAlert("Datos inválidos",
                "Verifique los datos ingresados.", "OK");
            return;
        }

        try
        {
            using (WebClient cliente = new WebClient())
            {
                var parametros = new NameValueCollection();
                parametros.Add("codigo", codigo.ToString());
                parametros.Add("nombre", txtNombre.Text.Trim());
                parametros.Add("apellido", txtApellido.Text.Trim());
                parametros.Add("edad", edad.ToString());

                string url = $"{Url}?codigo={codigo}" +
                    $"&nombre={Uri.EscapeDataString(txtNombre.Text.Trim())}" +
                    $"&apellido={Uri.EscapeDataString(txtApellido.Text.Trim())}" +
                    $"&edad={edad}";

                cliente.UploadValues(url, "PUT", new NameValueCollection());
            }

            await DisplayAlert("Éxito",
                "Estudiante actualizado correctamente.", "OK");

            await Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error al actualizar", ex.Message, "OK");
        }
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        bool confirmar = await DisplayAlert(
        "Confirmar eliminación",
        "¿Desea eliminar este estudiante?",
        "Sí", "No");

        if (!confirmar)
            return;

        if (!int.TryParse(txtCodigo.Text, out int codigo))
        {
            await DisplayAlert("Datos inválidos",
                "El código del estudiante no es válido.", "OK");
            return;
        }

        try
        {
            using (WebClient cliente = new WebClient())
            {
                cliente.UploadValues(
                    $"{Url}?codigo={codigo}",
                    "DELETE",
                    new NameValueCollection());
            }

            await DisplayAlert("Éxito",
                "Estudiante eliminado correctamente.", "OK");

            await Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error al eliminar", ex.Message, "OK");
        }
    }
}