using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public abstract class Cuenta
    {
        public string Codigo { get; }
        public Cliente Titular { get; private set; }
        public decimal Saldo { get; protected set; }
        public List<Movimiento> Movimientos { get; } = new();

        protected Cuenta(string codigo, Cliente titular)
        {
            if (string.IsNullOrWhiteSpace(codigo)) throw new ArgumentException("Código de cuenta obligatorio.");
            Codigo = codigo.Trim();
            Titular = titular ?? throw new ArgumentNullException(nameof(titular));
        }

        public void CambiarTitular(Cliente nuevoTitular)
        {
            Titular = nuevoTitular ?? throw new ArgumentNullException(nameof(nuevoTitular));
        }

        public virtual void Depositar(decimal importe)
        {
            if (importe <= 0) throw new ArgumentException("El importe a depositar debe ser positivo.");
            Saldo += importe;
            Movimientos.Add(new Movimiento(TipoOperacion.Deposito, importe));
        }

        public abstract void Extraer(decimal importe);
    }
}