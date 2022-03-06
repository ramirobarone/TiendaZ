using System;

namespace AppTiendaZ.Models
{
    public class EmptyException : Exception
    {
        public EmptyException(string message) : base(message)
        {

        }
    }
}
