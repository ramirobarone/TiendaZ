using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppTiendaZ.Models.Menu
{
    public class PreguntasFrecuente : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [JsonProperty("id")]
        public int Id { get; set; }
        public bool visible { get; set; }
        public int idPais { get; set; }

        private string _Icon;

        private bool _DescripcionVisible;
        private string _Titulo;
        private string _Descripcion;

        public string Icon
        {
            get => _Icon;
            set
            {
                _Icon = value;
                Changed();
            }
        }

        [JsonProperty("titulo")]
        public string Titulo
        {
            get => _Titulo;
            set
            {
                _Titulo = value;
                Changed();
            }
        }

        [JsonProperty("descripcion")]
        public string Descripcion
        {
            get => _Descripcion;
            set
            {
                _Descripcion = value;
                Changed();
            }
        }
        public bool DescripcionVisible
        {
            get { return _DescripcionVisible; }
            set
            {
                _DescripcionVisible = value;
                Changed();
            }
        }


        private void Changed([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
