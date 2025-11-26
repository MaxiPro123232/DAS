using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace Ejercicio02
{
    public class PaqueteNoEncontradoException : Exception
    {
        public PaqueteNoEncontradoException(string nombre) : base($"Paquete '{nombre}' no encontrado.") { }
    }
}
