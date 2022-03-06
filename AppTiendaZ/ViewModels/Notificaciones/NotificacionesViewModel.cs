using AppTiendaZ.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppTiendaZ.ViewModels.Notificaciones
{
    public class NotificacionesViewModel : BaseViewModel
    {
        public ICommand CommandClose { get; set; }
        private Notificacion _selectedNotification { get; set; }
        private List<Notificacion> _listNotification { get; set; }
        public Notificacion SelectedNotification
        {
            get => _selectedNotification;
            set
            {
                if (value != null)
                {
                    _selectedNotification = value;

                    _selectedNotification.DescriptionVisible = !value.DescriptionVisible;
                    _selectedNotification.Icon = value.DescriptionVisible == true ? "\ue93b" : "\ue93d";

                    NotifyPropertyChanged();
                }
            }
        }
        public List<Notificacion> ListNotification
        {
            get => _listNotification;
            set
            {
                if (value != null)
                {
                    _listNotification = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public NotificacionesViewModel(INavigation navigation)
        {
            NavigationService = navigation;
            LoadData();
            CommandClose = new Command(ClosePage);
        }

        public async void LoadData()
        {
            ApiService<Notificacion, Notificacion> api = new ApiService<Notificacion, Notificacion>();

            var response = await ExecuteBlocking(api.GetAll, new Notificacion() { IdCredito = Credito.idCredito }, Directions.DirectionsApi.Notificaciones);

            if (response.Result != null)
            {
                var list = new List<Notificacion>();
                foreach (var item in response.Result.ToList())
                {
                    var notification = item;
                    notification.Icon = "\ue93d";
                    list.Add(notification);
                }
                ListNotification = list;
            }
        }


        private void ClosePage()
        {
            NavigationService.PopAsync();
        }
    }
}
