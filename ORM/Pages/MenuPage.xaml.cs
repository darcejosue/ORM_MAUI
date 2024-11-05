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
            case "Inicio": page = new HomePage(); 
                break; 
            case "Ventas": page = new Sales(); 
                break;
            case "Inventario":
                page = new Inventario();
                break;
            case "Clientes":
                page = new Clientes();
                break;
            case "Proveedores":
                page = new Proveedores();
                break;
            case "Reportes":
                page = new Reportes();
                break;
        } 
        ((FlyoutPage)Application.Current.MainPage).Detail = new NavigationPage(page); 
        ((FlyoutPage)Application.Current.MainPage).IsPresented = false; }
}