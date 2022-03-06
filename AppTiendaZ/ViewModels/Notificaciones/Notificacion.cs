using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppTiendaZ.ViewModels.Notificaciones
{
    public class Notificacion : INotifyPropertyChanged
    {
        private string _icon { get; set; }
        private bool _DescriptionVisible { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Icon
        {
            get => _icon;
            set
            {
                if (value != null)
                {
                    _icon = value;
                    Changed();
                }
            }
        }
        public DateTime? FechaMensaje { get; set; }
        public DateTime? FechaLeido { get; set; }
        public bool? Leido { get; set; }
        public int IdCredito { get; set; }
        public string TokenPush { get; set; }

        public bool DescriptionVisible
        {
            get { return _DescriptionVisible; }
            set
            {

                _DescriptionVisible = value;
                Changed();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void Changed([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
