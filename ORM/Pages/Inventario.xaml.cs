using ORM.Componentes;
using ORM.Models;
using System.Collections.ObjectModel;

namespace ORM.Pages;

public partial class Inventario : ContentPage
{
	private ObservableCollection<ProductoModel> _products;
	private ObservableCollection<ProductoModel> _filteredProducts;
	public Inventario()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
        //ItemsListView.ItemsSource = await App.ProductoBase.GetProducts();
        var productos = await App.ProductoBase.GetProducts();
		_products = new ObservableCollection<ProductoModel>(productos);
		_filteredProducts = new ObservableCollection<ProductoModel>(_products);
        ItemsListView.ItemsSource = _filteredProducts.Take(25).ToList();

    }

	private void OnSearchBar(object sender, TextChangedEventArgs e)
	{
		var searchBar = e.NewTextValue;
		_filteredProducts.Clear();
		var filterItems = _products.Where(p => p.Nombre.ToLower().Contains(searchBar.ToLower()));
		foreach (var item in filterItems)
		{
			_filteredProducts.Add(item);
		}
	}
    private async void OnEditItemClicked(object sender, EventArgs e) {
        await Navigation.PushAsync(new NuevoInventario());
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