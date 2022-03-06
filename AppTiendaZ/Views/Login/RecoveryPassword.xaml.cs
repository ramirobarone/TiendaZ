using AppTiendaZ.ViewModels.LoginAccount;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTiendaZ.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecoveryPassword : ContentPage
    {
        public RecoveryPassword()
        {
            InitializeComponent();
            BindingContext = new RecoveryPasswordViewModel(Navigation);
        }
    }
}