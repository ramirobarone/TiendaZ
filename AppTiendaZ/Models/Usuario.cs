namespace AppTiendaZ.Models
{
    public class Usuario : Persona
    {
        public int IdCredito { get; set; }

        public string MensajeError { get; set; }
        public bool IsError { get; set; }
    }
}
