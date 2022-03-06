using AppTiendaZ.Models;
using Xamarin.Forms;

namespace AppTiendaZ.Views.TemplateSelector
{
    public class ViewCuotaSelector : DataTemplateSelector
    {
        private DataTemplate _CuotaResumida;
        private DataTemplate _CuotaCompleta;

        public ViewCuotaSelector()
        {
            _CuotaResumida = new DataTemplate(typeof(CuotaResumida));
            _CuotaCompleta = new DataTemplate(typeof(CuotaCompleta));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var cuota = item as Cuota;
            if (cuota.DiasMora > 0)
            {
                return _CuotaResumida;
            }
            else
            {
                return _CuotaCompleta;
            }
        }
    }
}
