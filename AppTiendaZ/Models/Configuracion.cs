using AppTiendaZ.Models.Menu;

namespace AppTiendaZ.Models
{
    public class Configuracion
    {


        public int idPais { get; set; }
        public Mediosdepago[] mediosDePago { get; set; }
        public PreguntasFrecuente[] preguntasFrecuentes { get; set; }
        public MenuApp[] menusApp { get; set; }
    }
}
