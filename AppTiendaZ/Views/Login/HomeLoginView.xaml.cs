using AppTiendaZ.ViewModels.LoginAccount;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTiendaZ.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeLoginView : ContentPage
    {
        public HomeLoginView()
        {
            InitializeComponent();
            BindingContext = new HomeLoginViewModel(Navigation);
        }
    }
}