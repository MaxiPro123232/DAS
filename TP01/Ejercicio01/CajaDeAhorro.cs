using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class CajaDeAhorro : Cuenta
    {
        public decimal TopeExtraccion { get; private set; }

        public CajaDeAhorro(string codigo, Cliente titular, decimal topeExtraccion)
            : base(codigo, titular)
        {
            if (topeExtraccion <= 0) throw new ArgumentException("El tope por extracción debe ser positivo.");
            TopeExtraccion = topeExtraccion;
        }

        public void CambiarTope(decimal nuevoTope)
        {
            if (nuevoTope <= 0) throw new ArgumentException("El tope por extracción debe ser positivo.");
            TopeExtraccion = nuevoTope;
        }

        public override void Extraer(decimal importe)
        {
            if (importe <= 0) throw new ArgumentException("El importe a extraer debe ser positivo.");
            if (importe > TopeExtraccion) throw new InvalidOperationException("Supera el tope por extracción de la Caja de Ahorro.");
            if (importe > Saldo) throw new InvalidOperationException("Saldo insuficiente en Caja de Ahorro.");

            Saldo -= importe;
            Movimientos.Add(new Movimiento(TipoOperacion.Extraccion, importe));
        }
    }
}