using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ejercicio02
{
    public class Contrato
    {
        public Cliente Cliente { get; set; }
        public Paquete Paquete { get; set; }
        public DateTime FechaInicio { get; set; }
        public double PrecioFinal => Paquete.CalcularPrecioFinal();

        public Contrato(Cliente cliente, Paquete paquete)
        {
            Cliente = cliente;
            Paquete = paquete;
            FechaInicio = DateTime.Now;
        }

        public override string ToString() => $"{Cliente} contrató {Paquete.Nombre} - ${PrecioFinal}";
    }
}
