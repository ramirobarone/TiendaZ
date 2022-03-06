using AppTiendaZ.Models;
using AppTiendaZ.Services;
using AppTiendaZ.Services.Interfaces;
using AppTiendaZ.Views.Login;
using AppTiendaZ.Views.Main;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTiendaZ
{
    public partial class App : Application
    {
        IServiceLocal<LoginModel> ServiceLocal;
        public App()
        {
            InitializeComponent();
            ServiceLocal = new ServiceLocal<LoginModel>();

            ServiceLocal.DeleteAccount();

            if (ServiceLocal.GetDataSettings(Directions.DirectionsApi.UserData) != null)
                MainPage = new MainShell();
            else
                MainPage = new NavigationPage(new HomeLoginView());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
