using System;

namespace AppTiendaZ.Models
{
    public class Cobro
    {
        public int Id { get; set; }
        public int IdCredito { get; set; }
        public DateTime FechaCobro { get; set; }
        public decimal InteresMoraCobrado { get; set; }
        public decimal InteresCobrado { get; set; }
        public decimal OriginacionCobrado { get; set; }
        public decimal CapitalCobrado { get; set; }
        public decimal TotalCobro { get; set; }
        public decimal CargoMoraCobrado { get; set; }
        public int Cuota { get; set; }
        public int DiasMora { get; set; }
    }
}
