using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppTiendaZ.ViewModels.LoginAccount
{
    public class CreateAccountViewModel : BaseViewModel
    {
        public ICommand CommandCreateAccount { get; set; }
        public ICommand CommandGoBack { get; set; }
        public string Identication { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Telephone { get; set; }
        public string Password { get; set; }
        public string RetryPassword { get; set; }

        public CreateAccountViewModel(INavigation navigation)
        {
            NavigationService = navigation;

            CommandCreateAccount = new Command(CreateAccountFunction);
            CommandGoBack = new Command(GoBack);
        }

        private async void CreateAccountFunction()
        {
            throw new NotImplementedException();
        }

        private void GoBack()
        {
            NavigationService.PopAsync();
        }
    }
}
