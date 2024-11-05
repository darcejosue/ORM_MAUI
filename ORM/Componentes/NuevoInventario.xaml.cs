using ORM.Models;

namespace ORM.Componentes;

public partial class NuevoInventario : ContentPage
{
	public NuevoInventario()
	{
		InitializeComponent();
		PopulatePickers();
	}

	private async Task PopulatePickers()
	{
		var proveedor = await App.ProveedorBase.GetProveedores();
		ProveedorPicker.ItemsSource = proveedor;
		ProveedorPicker.ItemDisplayBinding = new Binding("Nombre");

		var unidadesDeMedida = new List<string>
		{ "lb", "lts", "onz", "Unidad", "gr" };

		foreach (var unidad in unidadesDeMedida)
		{
			UnidadDeMedidaPicker.Items.Add(unidad);
		}
	}

	private async void OnSaveButtonClicked(object sender, EventArgs e)
	{
		if (ProveedorPicker.SelectedIndex == -1)
		{
			await DisplayAlert("Error", "Se debe de seleccionar un proveedor", "OK");
			return;
		}

		var producto = new ProductoModel
		{
            Nombre = NameEntry.Text,
            Proveedor = (ProveedorPicker.SelectedItem as ProveedorModel).Nombre,
            UnidadDeMedida = UnidadDeMedidaPicker.SelectedItem.ToString(),
            PrecioCompra = decimal.Parse(PrecioCompraEntry.Text),
            PrecioVenta = decimal.Parse(PrecioVentaEntry.Text),
            Cantidad = int.Parse(CantidadEntry.Text),
            FechaCaducidad = FechaCaducidadDatePicker.Date

        };

		await App.ProductoBase.SaveProduct(producto);
		await DisplayAlert("Producto Guardado", "El producto se guardo de manera correcta", "OK");
        // Limpiar los campos del formulario
		NameEntry.Text = string.Empty; 
		ProveedorPicker.SelectedIndex = -1;
		UnidadDeMedidaPicker.SelectedIndex = -1;
		PrecioCompraEntry.Text = string.Empty;
		PrecioVentaEntry.Text = string.Empty; 
		CantidadEntry.Text = string.Empty; 
		FechaCaducidadDatePicker.Date = DateTime.Now;

        await Navigation.PopAsync();
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}