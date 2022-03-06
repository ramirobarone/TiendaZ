
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTiendaZ.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MediosDePagoView : ContentPage
    {
        public MediosDePagoView()
        {
            InitializeComponent();
            BindingContext = new ViewModels.Menu.MediosDePagoViewModel(Navigation);
        }
    }
}