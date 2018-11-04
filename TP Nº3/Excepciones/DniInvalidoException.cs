using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
#pragma warning disable CS0169 // El campo 'DniInvalidoException._mensajeBase' nunca se usa
        private string _mensajeBase;
#pragma warning restore CS0169 // El campo 'DniInvalidoException._mensajeBase' nunca se usa

        public DniInvalidoException()
        {
        }

        public DniInvalidoException(string message) : base(message)
        {
        }

        public DniInvalidoException(Exception e) : base()
        {
        }

        public DniInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
