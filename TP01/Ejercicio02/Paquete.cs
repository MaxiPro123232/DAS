using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ejercicio02
{
    public abstract class Paquete
    {
        public string Nombre { get; set; }
        public double PrecioBase { get; set; }
        public List<Canal> Canales { get; set; } = new();

        public Paquete(string nombre, double precioBase)
        {
            Nombre = nombre;
            PrecioBase = precioBase;
        }

        public abstract double CalcularPrecioFinal();
    }
}
