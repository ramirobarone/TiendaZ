using AppTiendaZ.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppTiendaZ.ViewModels.AccountState
{
    public class AccountStateViewModel : BaseViewModel
    {
        private bool _CuotaVencidaVisible = false;
        private Cuota currentCuota;
        private ObservableCollection<Cuota> _PlanDePagos;

        public ICommand CommandCuota { get; set; }

        public AccountStateViewModel(INavigation navigation)
        {
            NavigationService = navigation;

            PlanDePagos = new ObservableCollection<Cuota>();
            CommandCuota = new Command(SeleccionarCuota);
            LoadAccountState();
        }

        private void SeleccionarCuota(object cuota)
        {
            CurrentCuota = null;
        }

        private void LoadAccountState()
        {
            foreach (var cuota in Cuotas)
            {
                if (cuota.numeroCuota != 0)
                    PlanDePagos.Add(CrearCuota(cuota));
            }
        }
        private Cuota CrearCuota(PlanDePago cuota)
        {
            try
            {
                return new Cuota()
                {
                    fechaVencimiento = cuota.fechaVencimiento,
                    fechaCancelacion = cuota.fechaCancelacion,
                    TextoCuota = "Cuota " + cuota.numeroCuota,
                    valorCuota = cuota.valorCuota,
                    abonado = cuota.abonado,
                    cargoPorAtraso = cuota.cargoPorAtraso,
                    DiasMora = cuota.diasEnAtraso > 0 ? cuota.diasEnAtraso : 0,
                    ColorEstado = EstadoCuotaColor(cuota),
                    IconoTilde = (cuota.diasEnAtraso > 0 && !cuota.cuotaCancelada) ? "\ue903" : "\ue938",
                    IconoFlecha = "\ue93d",
                    VistaCompleta = false,
                    id = cuota.numeroCuota,
                    valorTotalAtraso = cuota.valorTotalAtraso
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
        private Color EstadoCuotaColor(PlanDePago cuota)
        {
            if (cuota.fechaVencimiento.Date > DateTime.Now.Date)
                return Color.Default;
            else if (cuota.diasEnAtraso > 0 && !cuota.cuotaCancelada)
            {
                return Color.Red;
            }
            else
                return Color.Green;
        }
        private int CalcularDiasMora(PlanDePago cuota)
        {
            TimeSpan Dias;

            if (cuota.fechaVencimiento.Month == DateTime.Now.Date.Month)
                Dias = (TimeSpan)(cuota.fechaVencimiento - DateTime.Now);
            else
                return 0;

            return Dias.Days;
        }
        public ObservableCollection<Cuota> PlanDePagos
        {
            get => _PlanDePagos;
            set
            {
                if (value != null)
                {
                    _PlanDePagos = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool CuotaVencidaVisible
        {
            get => _CuotaVencidaVisible;
            set
            {
                _CuotaVencidaVisible = value;
                NotifyPropertyChanged();
            }
        }
        public Cuota CurrentCuota
        {
            get => currentCuota;
            set
            {
                if (value != null)
                {
                    currentCuota = value;
                    currentCuota.VistaCompleta = !currentCuota.VistaCompleta;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
