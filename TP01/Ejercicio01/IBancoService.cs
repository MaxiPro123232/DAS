using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public interface IBancoService
    {
        // Clientes
        void AltaCliente(Cliente cliente);
        void ModificarCliente(Cliente cliente);
        void EliminarCliente(string dni);

        // Cuentas
        void CrearCajaDeAhorro(string codigo, string dniTitular, decimal topeExtraccion);
        void CrearCuentaCorriente(string codigo, string dniTitular, decimal limiteDescubierto);
        void CambiarTitular(string codigoCuenta, string nuevoDniTitular);
        void EliminarCuenta(string codigoCuenta);

        // Movimientos
        void Depositar(string codigoCuenta, decimal importe);
        void Extraer(string codigoCuenta, decimal importe);

        // Consultas
        IEnumerable<Cliente> ListarClientes();
        Cliente? ObtenerCliente(string dni);
        IEnumerable<Cliente> BuscarClientesPorNombre(string texto);
        Cuenta? ObtenerCuenta(string codigo);
        IEnumerable<Cuenta> ListarCuentasDe(string dniTitular);
    }
}
