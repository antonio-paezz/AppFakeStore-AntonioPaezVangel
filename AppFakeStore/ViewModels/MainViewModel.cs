using AppFakeStore.Views;
using CommunityToolkit.Mvvm.Input;

namespace AppFakeStore.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    public MainViewModel()
    {
        Title = "FakeStoreApi";
    }

    [RelayCommand]
    public async Task GoToProductoLista()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new ProductoListaPage());
    }

    [RelayCommand]
    public async Task GoToUsuarioLista()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new UsuarioListaPage());
    }

    [RelayCommand]
    public async Task GoToAcerca()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new AcercaPage());
    }

    [RelayCommand]
    public async Task Exit()
    {
        bool result = await Application.Current.MainPage.DisplayAlert("Salir", "¿Desea terminar la sesión y salir?", "Aceptar", "Cancelar");

        if (result)
        {
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
