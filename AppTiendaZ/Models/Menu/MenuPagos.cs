namespace AppTiendaZ.Models.Menu
{
    public class MenuPagos
    {
        private int _Id;
        private string _Nombre;
        private string _Icon;

        public string Icon
        {
            get { return _Icon; }
            set { _Icon = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

    }
}
