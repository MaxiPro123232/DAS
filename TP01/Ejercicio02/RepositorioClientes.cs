using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace Ejercicio02
{
    public class RepositorioClientes
    {
        private List<Cliente> clientes = new();

        public void Agregar(Cliente c) => clientes.Add(c);

        public Cliente BuscarPorCodigo(int codigo)
        {
            var cliente = clientes.FirstOrDefault(c => c.CodigoCliente == codigo);
            if (cliente == null) throw new ClienteNoEncontradoException(codigo);
            return cliente;
        }

        public List<Cliente> Listar() => clientes;
    }
}
