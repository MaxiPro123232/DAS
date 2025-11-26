using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace Ejercicio02
{
    public class ClienteNoEncontradoException : Exception
    {
        public ClienteNoEncontradoException(int codigo) : base($"Cliente con código {codigo} no encontrado.") { }
    }
}
