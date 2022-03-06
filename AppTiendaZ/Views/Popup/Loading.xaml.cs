using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace AppTiendaZ.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Loading : PopupPage
    {
        public Loading()
        {
            InitializeComponent();

        }

        public Loading(bool textLoader)
        {
            InitializeComponent();
        }
    }
}