namespace AppTiendaZ.Models
{
    public class Comprobante
    {
        public int Id { get; set; }
        public string Banco { get; set; }
        public string NumeroComprobante { get; set; }
        public string EstadoComprobante { get; set; }
        public string FechaCarga { get; set; }
    }
}
