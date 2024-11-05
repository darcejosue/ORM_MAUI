using ORM.Componentes;
using ORM.Models;

namespace ORM.Pages;

public partial class Inventario : ContentPage
{
	private Item _currentItem;
	public Inventario()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
        ItemsListView.ItemsSource = await App.ProductoBase.GetProducts();
	}
    private void OnEditItemClicked(object sender, EventArgs e) {
		
	}

	private async void OnDeleteItemClicked(object sender, EventArgs e)
	{
        var menuItem = (Button)sender; 
		var item = (Item)menuItem.CommandParameter; 
		await App.Database.DeleteItemAsync(item); 
		ItemsListView.ItemsSource = await App.Database.GetItemsAsync();
    }

	private async void OnNavigateButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new NuevoInventario());
	}


}