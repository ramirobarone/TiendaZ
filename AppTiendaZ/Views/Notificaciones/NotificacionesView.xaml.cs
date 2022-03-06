using AppTiendaZ.ViewModels.Notificaciones;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTiendaZ.Views.Notificaciones
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificacionesView : ContentPage
    {
        public NotificacionesView()
        {
            InitializeComponent();
            BindingContext = new NotificacionesViewModel(Navigation);
        }
    }
}