using AppTiendaZ.ViewModels.Historial;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTiendaZ.Views.Historial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistorialView : ContentPage
    {
        public HistorialView()
        {
            InitializeComponent();
            BindingContext = new HistorialViewModel(Navigation);
        }
    }
}