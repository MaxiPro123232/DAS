using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace Ejercicio02
{
    public class RepositorioPaquetes
    {
        private List<Paquete> paquetes = new();
        public void Agregar(Paquete p) => paquetes.Add(p);
        public Paquete BuscarPorNombre(string nombre)
        {
            var paquete = paquetes.FirstOrDefault(p =>
                string.Equals(p.Nombre, nombre, StringComparison.OrdinalIgnoreCase));

            if (paquete == null) throw new PaqueteNoEncontradoException(nombre);
            return paquete;
        }
        public List<Paquete> Listar() => paquetes;
    }
}
