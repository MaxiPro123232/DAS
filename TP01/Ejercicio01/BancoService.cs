using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class BancoService : IBancoService
    {
        private readonly IRepositorioClientes _clientes;
        private readonly IRepositorioCuentas _cuentas;

        public BancoService(IRepositorioClientes clientes, IRepositorioCuentas cuentas)
        {
            _clientes = clientes;
            _cuentas = cuentas;
        }

        // Clientes
        public void AltaCliente(Cliente cliente)
        {
            if (_clientes.ExisteDni(cliente.Dni))
                throw new InvalidOperationException("DNI ya registrado.");
            _clientes.Agregar(cliente);
        }

        public void ModificarCliente(Cliente cliente)
        {
            if (!_clientes.ExisteDni(cliente.Dni))
                throw new KeyNotFoundException("Cliente inexistente.");
            _clientes.Modificar(cliente);
        }

        public void EliminarCliente(string dni)
        {
            // Sólo si no posee cuentas
            var cuentasDelCliente = _cuentas.ListarPorDniTitular(dni);
            if (cuentasDelCliente.Any())
                throw new InvalidOperationException("No se puede eliminar un cliente con cuentas asignadas.");
            _clientes.Eliminar(dni);
        }

        // Cuentas
        public void CrearCajaDeAhorro(string codigo, string dniTitular, decimal topeExtraccion)
        {
            if (_cuentas.ExisteCodigo(codigo)) throw new InvalidOperationException("Código de cuenta duplicado.");
            var titular = _clientes.ObtenerPorDni(dniTitular) ?? throw new KeyNotFoundException("Titular inexistente.");
            var cuenta = new CajaDeAhorro(codigo, titular, topeExtraccion);
            _cuentas.Agregar(cuenta);
        }

        public void CrearCuentaCorriente(string codigo, string dniTitular, decimal limiteDescubierto)
        {
            if (_cuentas.ExisteCodigo(codigo)) throw new InvalidOperationException("Código de cuenta duplicado.");
            var titular = _clientes.ObtenerPorDni(dniTitular) ?? throw new KeyNotFoundException("Titular inexistente.");
            var cuenta = new CuentaCorriente(codigo, titular, limiteDescubierto);
            _cuentas.Agregar(cuenta);
        }

        public void CambiarTitular(string codigoCuenta, string nuevoDniTitular)
        {
            var cuenta = _cuentas.ObtenerPorCodigo(codigoCuenta) ?? throw new KeyNotFoundException("Cuenta inexistente.");
            var nuevoTitular = _clientes.ObtenerPorDni(nuevoDniTitular) ?? throw new KeyNotFoundException("Nuevo titular inexistente.");
            cuenta.CambiarTitular(nuevoTitular);
        }

        public void EliminarCuenta(string codigoCuenta)
        {
            _cuentas.Eliminar(codigoCuenta); // valida saldo = 0
        }

        // Movimientos
        public void Depositar(string codigoCuenta, decimal importe)
        {
            var cuenta = _cuentas.ObtenerPorCodigo(codigoCuenta) ?? throw new KeyNotFoundException("Cuenta inexistente.");
            cuenta.Depositar(importe);
        }

        public void Extraer(string codigoCuenta, decimal importe)
        {
            var cuenta = _cuentas.ObtenerPorCodigo(codigoCuenta) ?? throw new KeyNotFoundException("Cuenta inexistente.");
            cuenta.Extraer(importe);
        }

        // Consultas
        public IEnumerable<Cliente> ListarClientes() => _clientes.Listar();
        public Cliente? ObtenerCliente(string dni) => _clientes.ObtenerPorDni(dni);
        public IEnumerable<Cliente> BuscarClientesPorNombre(string texto) => _clientes.BuscarPorNombre(texto);
        public Cuenta? ObtenerCuenta(string codigo) => _cuentas.ObtenerPorCodigo(codigo);
        public IEnumerable<Cuenta> ListarCuentasDe(string dniTitular) => _cuentas.ListarPorDniTitular(dniTitular);
    }
}
