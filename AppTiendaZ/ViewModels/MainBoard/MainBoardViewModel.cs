using AppTiendaZ.Models;
using AppTiendaZ.Services;
using AppTiendaZ.Services.Interfaces;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppTiendaZ.ViewModels.MainBoard
{
    public class MainBoardViewModel : BaseViewModel
    {
        private string _Nombre;
        private decimal? _MontoOriginacion;
        private decimal? _MontoCuota;
        private int _Plazo = 12;
        private int _Duracion;
        private string _Frecuencia;
        private string _FechaOriginacion;
        private string _MontoCuotaVencimiento;
        private string _TextoCuota = string.Empty;
        private int _CuotaActual = 0;
        private string _IdCredito;
        private string _PagasteCuotas;
        private bool _VerMora = false;
        private string _SubtituloCuota;
        private int _DiasEnMora;
        private decimal _MontoCuotaMora;
        private decimal _CargoPorAtrasos;
        private string _ProximoVencimiento;
        private Color _TextoColor;
        string specifier = "N";
        CultureInfo culture;
        private IApiService<Configuracion, Configuracion> ServicioConfiguraciones { get; set; }
        public ICommand CommandHelp { get; set; }
        public ICommand CommandNotificaciones { get; set; }
        public ICommand CommandGotoMediosDePago { get; set; }

        public MainBoardViewModel(INavigation navigation)
        {
            NavigationService = navigation;

            CommandHelp = new Command(ShowPopup);
            CommandNotificaciones = new Command(GotoNotification);
            ServicioConfiguraciones = new ApiService<Configuracion, Configuracion>();
            CommandGotoMediosDePago = new Command(GotToMediosPago);
            LoadDataUser();

            culture = CultureInfo.CreateSpecificCulture("es-ES");

        }
        private void GotToMediosPago(object obj)
        {
            NavigationService.PushAsync(new Views.Menu.MediosDePagoView());
        }

        private void GotoNotification()
        {
            NavigationService.PushAsync(new Views.Notificaciones.NotificacionesView());
        }

        private void LoadDataUser()
        {
            Nombre = $"{Credito.nombreCliente}";
            IdCredito = Credito.idCredito.ToString();

            Task.Run(async () =>
            {
                CargarDatosCredito();
                CargarCuotas();
                CargarConfiguracion();
            });
        }
        private async void CargarConfiguracion()
        {
            string uri = $"{Directions.DirectionsApi.Configuraciones}?IdPais={Directions.DirectionsApi.Pais.ToString()}";
            var serviceResponse = await ExecuteBlocking(ServicioConfiguraciones.Get, uri, silent: true);

            if (serviceResponse.Result != null)
            {
                Configuracion = serviceResponse.Result;
            }
        }
        private void CargarDatosCredito()
        {
            MontoOriginacion = Credito.montoCredito.ToString(specifier, culture);
            FechaOriginacion = Credito.fechaOriginacion.ToShortDateString();
            MontoCuota = Credito.montoCuota.ToString(specifier, culture);
            Plazo = Credito.duracionCredito > 0 ? (int)Credito.duracionCredito : 0;
            Frecuencia = Credito.frecuenciaDePago;
        }
        private void CargarCuotas()
        {
            MostrarValorCuota(Credito.cuotas);
            CargarCuotasBase(Credito.cuotas);
        }
        private void ShowPopup(object obj)
        {
            PopupNavigation.Instance.PushAsync(new Views.Popup.MessagePopup("El saldo en Mora está compuesto por la cuota que tenés pendiente, y los intereses generados por no pagar la cuota a tiempo. Si pagás el saldo en mora, estarás 100% día con sus pagos, hasta la fecha del próximo vencimiento."));
        }
        private void CargarCuotasBase(IEnumerable<PlanDePago> planDePagos)
        {
            if (Cuotas.Count > 0)
                Cuotas.Clear();

            foreach (var cuota in planDePagos)
            {
                Cuotas.Add(cuota);
            }
        }
        private void MostrarValorCuota(IEnumerable<PlanDePago> _Cuotas)
        {
            foreach (var Cuota in _Cuotas.AsParallel())
            {
                if (!Cuota.cuotaCancelada && Cuota.numeroCuota != 0)
                {
                    int DiasMora = Cuota.diasEnAtraso;
                    TextoColor = DiasMora > 0 ? Color.Red : Color.Default;
                    TextoCuota = DiasMora <= 0 ? "Proxima Cuota" : "Saldo En Mora";

                    SubtituloCuota = Cuota.fechaVencimiento < DateTime.Now.Date
                        ? $"Llevas {DiasMora.ToString()} días de atraso"
                        : $"Vencimiento {Cuota.fechaVencimiento.Date.ToShortDateString()}";

                    MontoProximaCuota = Cuota.valorCuota.ToString(specifier, culture);
                    CuotaActual = Cuota.numeroCuota == 0 ? 0 : Cuota.numeroCuota - 1;

                    PagasteCuotas = $"Pagaste { CuotaActual} de {Plazo} cuotas";

                    VerMora = Cuota.diasEnAtraso > 0;
                    CargoPorAtrasos = Cuota.cargoPorAtraso.ToString(specifier, culture);
                    MontoCuotaMora = Cuota.valorTotalAtraso.ToString(specifier, culture);
                    DiasEnMora = DiasMora;
                    ProximoVencimiento = Credito.cuotas
                                                .Where(x => x.numeroCuota == Cuota.numeroCuota + 1)
                                                .Select(x => x.fechaVencimiento)
                                                .FirstOrDefault().ToShortDateString();
                    break;
                }
            }
        }
        public string FormatoMoneda
        {
            get => Directions.DirectionsApi.SimboloMoneda;
        }
        public string Nombre
        {
            get
            {
                return "Hola, " + _Nombre;
            }
            set
            {
                _Nombre = value;
                NotifyPropertyChanged();
            }
        }
        public int CuotaActual
        {
            get => _CuotaActual;
            set
            {
                _CuotaActual = value;
                NotifyPropertyChanged();
            }
        }
        public string MontoProximaCuota
        {
            get { return Directions.DirectionsApi.SimboloMoneda + " " + _MontoCuotaVencimiento; }
            set
            {
                _MontoCuotaVencimiento = value;
                NotifyPropertyChanged();
            }
        }
        public string TextoCuota
        {
            get { return _TextoCuota; }
            set
            {
                _TextoCuota = value;
                NotifyPropertyChanged();
            }
        }
        public string PagasteCuotas
        {
            get => _PagasteCuotas;
            set
            {
                _PagasteCuotas = value;
                NotifyPropertyChanged();
            }
        }
        public string IdCredito
        {
            get => $"Número Cliente: {_IdCredito}";
            set
            {
                _IdCredito = value;
                NotifyPropertyChanged();
            }
        }
        public string MontoOriginacion
        {
            get => Directions.DirectionsApi.SimboloMoneda + " " + _MontoOriginacion;
            set
            {
                _MontoOriginacion = Convert.ToDecimal(value);
                NotifyPropertyChanged();
            }
        }
        public string MontoCuota
        {
            get => Directions.DirectionsApi.SimboloMoneda + " " + _MontoCuota.ToString();
            set
            {
                _MontoCuota = Convert.ToDecimal(value);
                NotifyPropertyChanged();
            }
        }
        public int Plazo
        {
            get => _Plazo;
            set
            {
                _Plazo = value;
                NotifyPropertyChanged();
            }
        }
        public int Duracion
        {
            get => _Duracion;
            set
            {
                _Duracion = value;
                NotifyPropertyChanged();
            }
        }
        public string Frecuencia
        {
            get => _Frecuencia;
            set
            {
                _Frecuencia = value;
                NotifyPropertyChanged();
            }
        }
        public string FechaOriginacion
        {
            get => _FechaOriginacion;
            set
            {
                _FechaOriginacion = value;
                NotifyPropertyChanged();
            }
        }
        public bool VerMora
        {
            get => _VerMora;
            set
            {
                _VerMora = value;
                NotifyPropertyChanged();
            }
        }
        public int DiasEnMora
        {
            get => _DiasEnMora;
            set { _DiasEnMora = value; NotifyPropertyChanged(); }
        }
        public string MontoCuotaMora
        {
            get => Directions.DirectionsApi.SimboloMoneda + " " + _MontoCuotaMora;
            set { _MontoCuotaMora = Convert.ToDecimal(value); NotifyPropertyChanged(); }
        }
        public string CargoPorAtrasos
        {
            get => Directions.DirectionsApi.SimboloMoneda + " " + _CargoPorAtrasos;
            set { _CargoPorAtrasos = Convert.ToDecimal(value); NotifyPropertyChanged(); }
        }
        public string ProximoVencimiento
        {
            get => _ProximoVencimiento;
            set { _ProximoVencimiento = value; NotifyPropertyChanged(); }
        }
        public string SubtituloCuota
        {
            get => _SubtituloCuota;
            set { _SubtituloCuota = value; NotifyPropertyChanged(); }
        }
        public Color TextoColor
        {
            get => _TextoColor;
            set
            {
                _TextoColor = value;
                NotifyPropertyChanged();
            }
        }
    }
}
