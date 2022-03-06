using AppTiendaZ.Models.Menu;
using AppTiendaZ.Views.Login;
using AppTiendaZ.Views.Notificaciones;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AppTiendaZ.ViewModels.Menu
{
    public class MenuViewModel : BaseViewModel
    {
        private MenuApp MenuSelected;
        private MenuApp selectOption { get; set; }
        public ObservableCollection<MenuApp> ListMenu { get; set; } = new ObservableCollection<MenuApp>();
        public MenuViewModel(INavigation navigation)
        {
            NavigationService = navigation;
            LoadMenuItem();
        }
        public MenuApp SelectOption
        {
            get => selectOption;
            set
            {
                if (value != null)
                {
                    selectOption = value;
                    NavigateTo(selectOption.Id);
                }
            }
        }

        private void LoadMenuItem()
        {
            ListMenu.Add(new MenuApp() { Id = 1, NameMenu = "Preguntas Frecuentes", Icon = "\ue97e" });
            ListMenu.Add(new MenuApp() { Id = 2, NameMenu = "Medios de Pago", Icon = "\ue95c" });
            ListMenu.Add(new MenuApp() { Id = 3, NameMenu = "Notificaciones", Icon = "\ue926", });
            ListMenu.Add(new MenuApp() { Id = 4, NameMenu = "Soporte / Ayuda", Icon = "\ue9a5" });
            //ListMenu.Add(new MenuApp() { Id = 5, NameMenu = "Descargar contrato", Icon = "\ue95e" });
            //ListMenu.Add(new MenuApp() { Id = 6, NameMenu = "Descargar pagaré", Icon = "\ue95e" });
            ListMenu.Add(new MenuApp() { Id = 7, NameMenu = "Generar promesa de pago", Icon = "\ue9a5" });
            ListMenu.Add(new MenuApp() { Id = 8, NameMenu = "Reportar un pago", Icon = "\ue9a5" });
            ListMenu.Add(new MenuApp() { Id = 9, NameMenu = "Cerrar ", Icon = "\ue9d4" });
            //ListMenu.Add(new MenuApp() { Id = 9, NameMenu = "Descargar carta de finiquito", Icon = "\ue95e" });

        }

        private void NavigateTo(int id)
        {
            switch (id)
            {
                case 1:
                    {
                        NavigationService.PushAsync(new Views.Menu.PreguntasFrecuentes());
                        break;
                    }
                case 2:
                    NavigationService.PushAsync(new Views.Menu.MediosDePagoView());
                    break;
                case 3:
                    {
                        NavigationService.PushAsync(new NotificacionesView());
                        break;
                    }
                case 7:
                    {
                        Xamarin.Essentials.Launcher.OpenAsync("https://wa.me/18494104542?text=Quiero%20generar%20una%20promesa%20de%20pago");
                        break;
                    }
                case 8:
                    {
                        Xamarin.Essentials.Launcher.OpenAsync("https://wa.me/18494104542?text=Quiero%20reportar%20un%20pago");
                        break;
                    }
                case 9:
                    {
                        App.Current.MainPage = new NavigationPage(new HomeLoginView());
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
