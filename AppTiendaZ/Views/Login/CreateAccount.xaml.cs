using AppTiendaZ.ViewModels.LoginAccount;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTiendaZ.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccount : ContentPage
    {
        public CreateAccount()
        {
            InitializeComponent();
            BindingContext = new CreateAccountViewModel(Navigation);
        }
    }
}