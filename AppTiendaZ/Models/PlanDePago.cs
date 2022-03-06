using System;

namespace AppTiendaZ.Models
{
    public class PlanDePago
    {
        public int numeroCuota { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public DateTime fechaCancelacion { get; set; }
        public float valorCuota { get; set; }
        public float cargoPorAtraso { get; set; }
        public float abonado { get; set; }
        public float valorTotalAtraso { get; set; }
        public int diasEnAtraso { get; set; }
        public bool cuotaCancelada { get; set; }
        public int id { get; set; }
    }
}
