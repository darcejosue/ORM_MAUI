using ORM.Controllers;
using ORM.Models;

namespace ORM.Componentes;

public partial class NuevoProveedor : ContentPage
{
	private ProveedorModel _currentProveedor;
	public NuevoProveedor()
	{
		InitializeComponent();
		
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		ProveedorListView.ItemsSource = await App.ProveedorBase.GetProveedores();
    }
    
    private async void OnAddProveedorClicked(object sender, EventArgs e)
	{
		if(_currentProveedor == null)
		{
			var proveedor = new ProveedorModel
			{
				Nombre = NombreEntry.Text,
				Telfefono = TelefonoEntry.Text
            };

			await App.ProveedorBase.SaveProveedor(proveedor);
		}

        ProveedorListView.ItemsSource = await App.ProveedorBase.GetProveedores();

    }
}