using AppTiendaZ.Views.Login;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppTiendaZ.ViewModels.LoginAccount
{
    public class HomeLoginViewModel : BaseViewModel
    {

        public ICommand GotoLogin { get; set; }
        public HomeLoginViewModel(INavigation navigation)
        {
            NavigationService = navigation;

            GotoLogin = new Command(Goto);
        }

        private void Goto()
        {
            NavigationService.PushAsync(new LoginPage());
        }
    }
}
