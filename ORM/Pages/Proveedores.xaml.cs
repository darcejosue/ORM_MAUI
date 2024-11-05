using ORM.Componentes;

namespace ORM.Pages;

public partial class Proveedores : ContentPage
{
	public Proveedores()
	{
		InitializeComponent();
	}

	private async void Nuevo_Proveedor(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new NuevoProveedor());
	}
}