using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class RepositorioClientes : IRepositorioClientes
    {
        private readonly Dictionary<string, Cliente> _porDni = new(StringComparer.OrdinalIgnoreCase);

        public void Agregar(Cliente cliente)
        {
            if (ExisteDni(cliente.Dni)) throw new InvalidOperationException("Ya existe un cliente con ese DNI.");
            _porDni[cliente.Dni] = cliente;
        }

        public void Modificar(Cliente cliente)
        {
            if (!_porDni.ContainsKey(cliente.Dni)) throw new KeyNotFoundException("Cliente inexistente.");
            _porDni[cliente.Dni] = cliente;
        }

        public void Eliminar(string dni)
        {
            _porDni.Remove(dni);
        }

        public Cliente? ObtenerPorDni(string dni)
            => _porDni.TryGetValue(dni, out var c) ? c : null;

        public IEnumerable<Cliente> BuscarPorNombre(string texto)
        {
            texto ??= string.Empty;
            return _porDni.Values
                .Where(c => c.NombreApellido.Contains(texto, StringComparison.OrdinalIgnoreCase))
                .OrderBy(c => c.NombreApellido);
        }

        public IEnumerable<Cliente> Listar() => _porDni.Values.OrderBy(c => c.NombreApellido);

        public bool ExisteDni(string dni) => _porDni.ContainsKey(dni);
    }
}
