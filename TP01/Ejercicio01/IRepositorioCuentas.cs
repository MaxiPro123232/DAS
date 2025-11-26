using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public interface IRepositorioCuentas
    {
        void Agregar(Cuenta cuenta);                   // Código único, titular debe existir
        void Eliminar(string codigo);                  // sólo si saldo = 0
        Cuenta? ObtenerPorCodigo(string codigo);
        IEnumerable<Cuenta> ListarPorDniTitular(string dni);
        bool ExisteCodigo(string codigo);
    }
}
