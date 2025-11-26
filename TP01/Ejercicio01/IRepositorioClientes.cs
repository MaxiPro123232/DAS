using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public interface IRepositorioClientes
    {
        void Agregar(Cliente cliente);                
        void Modificar(Cliente cliente);              
        void Eliminar(string dni);                   
        Cliente? ObtenerPorDni(string dni);
        IEnumerable<Cliente> BuscarPorNombre(string texto);
        IEnumerable<Cliente> Listar();
        bool ExisteDni(string dni);
    }
}