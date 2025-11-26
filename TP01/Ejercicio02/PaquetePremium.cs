using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace Ejercicio02
{
    public class PaquetePremium : Paquete
    {
        public PaquetePremium(string nombre, double precioBase) : base(nombre, precioBase) { }
        public override double CalcularPrecioFinal() => PrecioBase * 1.20;
    }
}
