using ORM.Controllers;
using ORM.Pages;
using ORM.Services;

namespace ORM
{
    public partial class App : Application
    {
        #region base de datos
        static DatabaseService database;
        public static DatabaseService Database
        {
            get
            {
                if (database == null) {
                    database = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tienda.db3"));
                }
                return database;
            }
        }

        static ProveedorController proveedorController;
        public static ProveedorController ProveedorBase
        {
            get
            {
                if (proveedorController == null)
                {
                    proveedorController = new ProveedorController(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tienda.db3"));
                }
                return proveedorController;
            }
        }

        static ProductoController productoController;
        public static ProductoController ProductoBase
        {
            get
            {
                if (productoController == null)
                {
                    productoController = new ProductoController(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tienda.db3"));
                }
                return productoController;
            }
        }

        #endregion

        public App()
        {
            InitializeComponent();

            MainPage = new FlyoutPage
            {
                Flyout = new MenuPage(),
                Detail = new NavigationPage(new HomePage())
            };
        }
    }
}
