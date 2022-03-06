using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms.Xaml;

namespace AppTiendaZ.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupCuotaResumida : PopupPage
    {
        public PopupCuotaResumida(string FechaVencimiento, string ValorCuota)
        {
            InitializeComponent();

            txt_FechaVencimiento.Text = FechaVencimiento;
            txt_ValorCuota.Text = ValorCuota;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}