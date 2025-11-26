using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class ClienteDuplicadoException : Exception
    {
        public ClienteDuplicadoException(string dni) : base($"Ya existe un cliente con DNI {dni}.") { }
    }

    public class ClienteConCuentasException : Exception
    {
        public ClienteConCuentasException(string dni) : base($"El cliente {dni} posee cuentas y no puede eliminarse.") { }
    }

    public class ClienteNoExisteException : Exception
    {
        public ClienteNoExisteException(string dni) : base($"No existe cliente con DNI {dni}.") { }
    }

    public class CuentaDuplicadaException : Exception
    {
        public CuentaDuplicadaException(string codigo) : base($"Ya existe una cuenta con código {codigo}.") { }
    }

    public class CuentaNoExisteException : Exception
    {
        public CuentaNoExisteException(string codigo) : base($"No existe cuenta con código {codigo}.") { }
    }

    public class CuentaConSaldoException : Exception
    {
        public CuentaConSaldoException(string codigo) : base($"La cuenta {codigo} tiene saldo distinto de cero.") { }
    }

    public class ExtraccionInvalidaException : Exception
    {
        public ExtraccionInvalidaException(string motivo) : base($"Extracción inválida: {motivo}") { }
    }

    public class DatoObligatorioVacioException : Exception
    {
        public DatoObligatorioVacioException(string nombreCampo) : base($"El campo '{nombreCampo}' es obligatorio.") { }
    }
}
