using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace BilleteraPais.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupMessage : PopupPage
    {
        public PopupMessage()
        {
            InitializeComponent();
        }
        public PopupMessage(string title, string message)
        {
            InitializeComponent();
            titleControl.Text = title;
            messageControl.Text = message;
        }

        private async void closeControl_Clicked(object sender, System.EventArgs e)
        {
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }
    }
}