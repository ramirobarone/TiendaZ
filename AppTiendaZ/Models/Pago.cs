using System;

namespace AppTiendaZ.Models
{
    public class Pago
    {
        public string cuota { get; set; }
        public DateTime fechaPago { get; set; }
        public float montoAbonado { get; set; }
        public int id { get; set; }
        public string MontoConFormato { get => Directions.DirectionsApi.SimboloMoneda + " " + montoAbonado; }
    }
}
