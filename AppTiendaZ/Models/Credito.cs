using System;
using System.Collections.Generic;

namespace AppTiendaZ.Models
{
    public class Credito
    {

        public string nombreCliente { get; set; }
        public int idCredito { get; set; }
        public Cuota[] cuotas { get; set; }
        public IList<Pago> pagos { get; set; }
        public int duracionCredito { get; set; }
        public int montoCredito { get; set; }
        public decimal montoCuota { get; set; }
        public DateTime fechaOriginacion { get; set; }
        public string frecuenciaDePago { get; set; }
        public int id { get; set; }
    }

}
