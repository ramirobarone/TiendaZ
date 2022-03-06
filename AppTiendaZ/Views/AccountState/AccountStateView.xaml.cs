using AppTiendaZ.ViewModels.AccountState;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTiendaZ.Views.AccountState
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountStateView : ContentPage
    {
        public AccountStateView()
        {
            InitializeComponent();
            BindingContext = new AccountStateViewModel(Navigation);
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (LstCuotas.SelectedItem != null)
                LstCuotas.SelectedItem = null;
        }
    }
}