namespace ORM.Pages;

public partial class MenuPage : ContentPage
{
	public MenuPage()
	{
		InitializeComponent();
        MenuItemsListView.ItemSelected += OnItemSelected;
    }

    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e) 
    { if (e.SelectedItem == null) return; 
        Page page = null; switch (e.SelectedItem.ToString()) 
        { 
            case "Home": page = new HomePage(); 
                break; 
            case "Ventas": page = new Sales(); 
                break; 
        } 
        ((FlyoutPage)Application.Current.MainPage).Detail = new NavigationPage(page); 
        ((FlyoutPage)Application.Current.MainPage).IsPresented = false; }
}