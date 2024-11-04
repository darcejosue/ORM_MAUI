using ORM.Pages;

namespace ORM
{
    public partial class App : Application
    {
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
