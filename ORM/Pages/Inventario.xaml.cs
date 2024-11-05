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
        ItemsListView.ItemsSource = await App.Database.GetItemsAsync();
	}
    private async void OnAddItemClicked(object sender, EventArgs e)
    {
		if (_currentItem == null)
		{
            var item = new Item
            {
                Name = NameEntry.Text,
                Description = DescriptionEntry.Text
            };

            await App.Database.SaveItemAsync(item);

		}
		else
		{
			_currentItem.Name = NameEntry.Text;
			_currentItem.Description = DescriptionEntry.Text;
			await App.Database.SaveItemAsync(_currentItem);
			_currentItem = null;
		}

        ItemsListView.ItemsSource = await App.Database.GetItemsAsync();
        NameEntry.Text = string.Empty;
        DescriptionEntry.Text = string.Empty;
    }
    private void OnEditItemClicked(object sender, EventArgs e) {
		var button = (Button)sender; 
		_currentItem = (Item)button.CommandParameter; 
		NameEntry.Text = _currentItem.Name; 
		DescriptionEntry.Text = _currentItem.Description; 
	}

	private async void OnDeleteItemClicked(object sender, EventArgs e)
	{
        var menuItem = (Button)sender; 
		var item = (Item)menuItem.CommandParameter; 
		await App.Database.DeleteItemAsync(item); 
		ItemsListView.ItemsSource = await App.Database.GetItemsAsync();
    }


}