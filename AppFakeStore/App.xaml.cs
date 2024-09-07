using AppFakeStore.Services;
using AppFakeStore.ViewModels;
using AppFakeStore.Views;

namespace AppFakeStore
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var loginService = new LoginService();
            MainPage = new NavigationPage(new LoginPage
            {
                BindingContext = new LoginViewModel(loginService)
            });
        }
    }
}
