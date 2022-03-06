using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace AppTiendaZ.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagePopup : PopupPage
    {
        public MessagePopup(string message)
        {
            InitializeComponent();
            textoMensaje.Text = message;
        }
    }
}