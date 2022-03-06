using System;

namespace AppTiendaZ.Models
{
    internal class CommunicationException : Exception
    {
        public string coom { get; set; }

        public CommunicationException(string msj) : base(msj)
        {

        }
    }
}
