using AppTiendaZ.Models;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace AppTiendaZ.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupCuota : PopupPage
    {
        public PopupCuota(Cuota cuota)
        {
            InitializeComponent();

            txt_FechaVencimiento.Text = cuota.fechaVencimiento.ToShortDateString();
            txt_CargosPorAtraso.Text = cuota.cargoPorAtraso.ToString();
            txt_DiasEnAtraso.Text = cuota.DiasMora.ToString();
            txt_FechaCancelacion.Text = cuota.fechaCancelacion.ToShortDateString();
            txt_HasPagado.Text = cuota.abonado.ToString();
            txt_ValorOriginalCuota.Text = cuota.valorCuota.ToString();
            txt_ValorTotalAtraso.Text = cuota.valorTotalAtraso.ToString();
        }
    }
}