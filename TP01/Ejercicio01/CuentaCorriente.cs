using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class CuentaCorriente : Cuenta
    {
        public decimal LimiteDescubierto { get; private set; } 

        public CuentaCorriente(string codigo, Cliente titular, decimal limiteDescubierto)
            : base(codigo, titular)
        {
            if (limiteDescubierto < 0) throw new ArgumentException("El límite de descubierto no puede ser negativo.");
            LimiteDescubierto = limiteDescubierto;
        }

        public void CambiarLimiteDescubierto(decimal nuevoLimite)
        {
            if (nuevoLimite < 0) throw new ArgumentException("El límite de descubierto no puede ser negativo.");
            LimiteDescubierto = nuevoLimite;
        }

        public override void Extraer(decimal importe)
        {
            if (importe <= 0) throw new ArgumentException("El importe a extraer debe ser positivo.");
            var saldoPosterior = Saldo - importe;
            if (saldoPosterior < -LimiteDescubierto)
                throw new InvalidOperationException("Supera el límite de descubierto permitido.");

            Saldo -= importe;
            Movimientos.Add(new Movimiento(TipoOperacion.Extraccion, importe));
        }
    }
}