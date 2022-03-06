using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppTiendaZ.ViewModels.LoginAccount
{
    public class RecoveryPasswordViewModel : BaseViewModel
    {
        public ICommand CommandRecoveryAccount { get; set; }
        public ICommand CommandGoBack { get; set; }
        public string Email { get; set; }
        public RecoveryPasswordViewModel(INavigation navigation)
        {
            NavigationService = navigation;

            CommandGoBack = new Command(GoBack);
            CommandRecoveryAccount = new Command(RecoveryAccount);
        }

        private void RecoveryAccount()
        {
            throw new NotImplementedException();
        }

        private void GoBack()
        {
            NavigationService.PopAsync();
        }
    }
}
