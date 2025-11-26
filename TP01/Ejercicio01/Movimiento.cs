using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public enum TipoOperacion { Deposito, Extraccion }

    public class Movimiento
    {
        public DateTime Fecha { get; }
        public TipoOperacion Tipo { get; }
        public decimal Importe { get; }

        public Movimiento(TipoOperacion tipo, decimal importe)
        {
            Fecha = DateTime.Now;
            Tipo = tipo;
            Importe = importe;
        }
    }
}