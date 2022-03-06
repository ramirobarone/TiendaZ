using AppTiendaZ.Models.Menu;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppTiendaZ.ViewModels.Menu
{
    public class MediosDePagoViewModel : BaseViewModel
    {
        public ObservableCollection<Mediosdepago> MediosDePagos { get; set; } = new ObservableCollection<Mediosdepago>();
        public ObservableCollection<MenuPagos> MenuDePagos { get; set; } = new ObservableCollection<MenuPagos>();

        public ICommand OpenDescriptionCommand { get; set; }
        public ICommand OpenDescriptionTransferenciaCommand { get; set; }
        public ICommand CommandBackTo { get; set; }

        private bool _EstafetaVisible = false;
        private bool _TransferenciaVisible = false;

        public MediosDePagoViewModel(INavigation navigation)
        {
            NavigationService = navigation;

            OpenDescriptionCommand = new Command(VerEstafeta);
            OpenDescriptionTransferenciaCommand = new Command(VerTransferencia);
            CommandBackTo = new Command(Back);
            CargaMenuPagos();
            CargarMediosDePago();
        }
        public bool TransferenciaVisible
        {
            get { return _TransferenciaVisible; }
            set
            {
                _TransferenciaVisible = value;
                NotifyPropertyChanged();
            }
        }
        private void Back()
        {
            NavigationService.PopAsync();
        }

        private void VerTransferencia()
        {
            TransferenciaVisible = !TransferenciaVisible;
        }

        public bool EstafetaVisible
        {
            get => _EstafetaVisible;
            set
            {
                _EstafetaVisible = value;
                NotifyPropertyChanged();
            }
        }
        private void VerEstafeta()
        {
            EstafetaVisible = !EstafetaVisible;
        }
        private void CargaMenuPagos()
        {
            MenuDePagos.Add(new MenuPagos()
            {
                Id = 0,
                Nombre = "Depositos en Estafeta",
                Icon = "\ue93d"
            });
            MenuDePagos.Add(new MenuPagos()
            {
                Id = 1,
                Nombre = "Transferencia",
                Icon = "\ue93d"
            });
        }

        private void CargarMediosDePago()
        {
            if (Configuracion.mediosDePago != null)
                foreach (var item in Configuracion.mediosDePago)
                {
                    item.Icon = "\ue93d";
                    MediosDePagos.Add(item);
                }
        }

    }
}
