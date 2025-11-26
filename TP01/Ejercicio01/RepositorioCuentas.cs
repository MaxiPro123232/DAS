using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class RepositorioCuentas : IRepositorioCuentas
    {
        private readonly Dictionary<string, Cuenta> _porCodigo = new(StringComparer.OrdinalIgnoreCase);

        public void Agregar(Cuenta cuenta)
        {
            if (ExisteCodigo(cuenta.Codigo)) throw new InvalidOperationException("Ya existe una cuenta con ese código.");
            _porCodigo[cuenta.Codigo] = cuenta;
        }

        public void Eliminar(string codigo)
        {
            if (!_porCodigo.TryGetValue(codigo, out var c)) throw new KeyNotFoundException("Cuenta inexistente.");
            if (c.Saldo != 0) throw new InvalidOperationException("No se puede eliminar una cuenta con saldo distinto de cero.");
            _porCodigo.Remove(codigo);
        }

        public Cuenta? ObtenerPorCodigo(string codigo)
            => _porCodigo.TryGetValue(codigo, out var c) ? c : null;

        public IEnumerable<Cuenta> ListarPorDniTitular(string dni)
            => _porCodigo.Values.Where(c => c.Titular.Dni.Equals(dni, StringComparison.OrdinalIgnoreCase));

        public bool ExisteCodigo(string codigo) => _porCodigo.ContainsKey(codigo);
    }
}
