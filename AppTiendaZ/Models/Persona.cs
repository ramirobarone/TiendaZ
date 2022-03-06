using System;

namespace AppTiendaZ.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public int? IdTipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public DateTime? VencimientoIdentificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int? TelefonoCel { get; set; }
        public string Correo { get; set; }

    }
}
