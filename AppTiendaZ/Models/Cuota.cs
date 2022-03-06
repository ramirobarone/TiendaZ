using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace AppTiendaZ.Models
{
    public class Cuota : PlanDePago, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string IconoTilde { get => _IconoTilde; set { _IconoTilde = value; NotifyProperty(); } }
        public Color ColorEstado { get => _ColorEstado; set { _ColorEstado = value; NotifyProperty(); } }
        public string IconoFlecha { get => _IconoFlecha; set { _IconoFlecha = value; NotifyProperty(); } }
        public int DiasMora { get => _DiasMora; set { _DiasMora = value; NotifyProperty(); } }
        public string TextoCuota { get => _TextoCuota; set { _TextoCuota = value; NotifyProperty(); } }
        public bool VistaCompleta { get => _VistaCompleta; set { _VistaCompleta = value; NotifyProperty(); } }

        private void NotifyProperty([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private string _IconoTilde;
        private Color _ColorEstado;
        private string _IconoFlecha;
        private int _DiasMora;
        private string _TextoCuota;
        private bool _VistaCompleta;
    }
}
