using AppTiendaZ.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppTiendaZ.ViewModels.Historial
{
    public class HistorialViewModel : BaseViewModel
    {
        public ICommand HistorialTapped { get; set; }
        public ICommand CalendarioTapped { get; set; }
        private string _iconHistorial;
        private bool _historialVisible;
        private bool _calendarioVisible;
        private string _iconCalendario;

        private List<Cuota> _listaCalendario { get; set; }
        private List<Pago> _listaPago { get; set; }

        public HistorialViewModel(INavigation navigation)
        {
            NavigationService = navigation;
            HistorialTapped = new Command(EstadoHistorial);
            CalendarioTapped = new Command(EstadoCalendario);
            Task.Run(() => LoadData());
        }

        public List<Cuota> ListaCalendario
        {
            get => _listaCalendario;
            set
            {
                if (value != null)
                {
                    _listaCalendario = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public List<Pago> ListaPago
        {
            get => _listaPago;
            set
            {
                if (value != null)
                {
                    _listaPago = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool HistorialVisible
        {
            get => _historialVisible;
            set
            {
                _historialVisible = value;
                NotifyPropertyChanged();
            }
        }
        public string IconHistorial
        {
            get => _iconHistorial;
            set
            {
                if (value != null)
                {
                    _iconHistorial = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool CalendarioVisible
        {
            get => _calendarioVisible;
            set
            {
                _calendarioVisible = value;
                NotifyPropertyChanged();
            }
        }
        public string IconCalendario
        {
            get => _iconCalendario;
            set
            {
                if (value != null)
                {
                    _iconCalendario = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private void EstadoHistorial()
        {
            HistorialVisible = HistorialVisible == true ? false : true;
            IconHistorial = HistorialVisible ? "\ue93b" : "\ue93d";
        }

        private void EstadoCalendario()
        {
            CalendarioVisible = CalendarioVisible == true ? false : true;
            IconCalendario = CalendarioVisible ? "\ue93b" : "\ue93d";
        }

        public void LoadData()
        {
            IconHistorial = "\ue93d";
            IconCalendario = "\ue93d";

            if (Credito.pagos != null)
            {
                ListaPago = Credito.pagos.ToList();
            }

            if (Cuotas != null)
            {
                ListaCalendario = Credito.cuotas.ToList();
                ListaCalendario.RemoveAt(0);
            }
        }
        public string FormatoMoneda
        {
            get => Directions.DirectionsApi.SimboloMoneda;
        }
    }
}
