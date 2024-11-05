using ORM.Pages;
using ORM.Services;

namespace ORM
{
    public partial class App : Application
    {
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
