using rtoapantaTallerS6.Models;

namespace rtoapantaTallerS6.Views;

public partial class vActualizarEliminar : ContentPage
{
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

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {

    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {

    }
}