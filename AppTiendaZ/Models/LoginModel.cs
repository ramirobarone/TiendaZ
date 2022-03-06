using AppTiendaZ.Directions;
using Prism.Mvvm;

namespace AppTiendaZ.Models
{
    public class LoginModel : BindableBase
    {
        private string _Identificacion;
        private int _IdCredito;

        public string Identificacion
        {
            get => _Identificacion;
            set => SetProperty(ref _Identificacion, value);
        }
        public int IdCredito
        {
            get => _IdCredito;
            set => SetProperty(ref _IdCredito, value);
        }
        public int Pais
        {
            get => (int)Paises.Dominicana;
        }
    }

}
