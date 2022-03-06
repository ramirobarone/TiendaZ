using AppTiendaZ.Models;
using AppTiendaZ.Services;
using AppTiendaZ.Views.Login;
using AppTiendaZ.Views.Main;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppTiendaZ.ViewModels.LoginAccount
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand CommandLogIn { get; set; }
        public ICommand CommandNoTengoNumero { get; set; }
        public ICommand CommandClose { get; set; }
        public string Identificacion { get; set; }
        public string IdCredito { get; set; }
        public bool Chechek { get; set; }
        private PlanDePago _Cuota;


        private ApiService<LoginModel, Credito> LoginService;
        private readonly ServiceLocal<Usuario> ServiceLocal;
        public LoginViewModel(INavigation _navigation)
        {
            NavigationService = _navigation;
            ServiceLocal = new ServiceLocal<Usuario>();
            Init();
        }
        private void Init()
        {
            CommandLogIn = new Command(Login);
            CommandNoTengoNumero = new Command(GoToRecoveryNumberCredit);
            CommandClose = new Command(GoBack);

            LoginService = new ApiService<LoginModel, Credito>();
        }
        private void GoBack()
        {
            NavigationService.PopAsync();
        }

        private void GoToRecoveryNumberCredit()
        {
            NavigationService.PushAsync(new RecoveryPassword());
        }
        private async void Login()
        {
            int _idCredito;

#if DEBUG
            Identificacion = "111400446";
            IdCredito = 832.ToString();
#endif


            if (!string.IsNullOrEmpty(Identificacion) && Int32.TryParse(IdCredito, out _idCredito) && !string.IsNullOrEmpty(IdCredito))
            {
                var responseCredito = await ExecuteBlocking(LoginService.Post, Directions.DirectionsApi.Credito, new LoginModel()
                {
                    Identificacion = this.Identificacion,
                    IdCredito = _idCredito,
                });

                if (responseCredito.Result != null)
                {
                    Credito = responseCredito.Result;

                    App.Current.MainPage = new MainShell();
                }
                else
                {
                    await DialogService.DisplayAlertAsync("Error", "Controle su identificación y número de cliente para poder acceder", "Aceptar");
                }
            }
        }
        public PlanDePago Cuota
        {
            get => _Cuota;
            set
            {
                _Cuota = value;
                NotifyPropertyChanged();
            }
        }
    }
}
