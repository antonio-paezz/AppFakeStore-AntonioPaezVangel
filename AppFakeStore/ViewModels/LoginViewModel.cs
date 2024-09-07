using AppFakeStore.Services;
using System.Windows.Input;
using AppFakeStore.Views;

namespace AppFakeStore.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly ILoginService _loginService;

        public LoginViewModel()
        {
            _loginService = new LoginService(); 
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand { get; }

        public LoginViewModel(ILoginService loginService)
        {
            _loginService = loginService;
            LoginCommand = new Command(async () => await LoginAsync());
        }

        private async Task LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debe de ingresar usuario y contraseña", "OK");
                return;
            }

            var token = await _loginService.GetTokenAsync(Username, Password);
            if (!string.IsNullOrEmpty(token))
            {
                await App.Current.MainPage.DisplayAlert("Éxito", "Se ha iniciado sesión correctamente", "OK");
                await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Error al ingresar Usuario o Contraseña, Intente nuevamente", "OK");
            }
        }
    }
}
