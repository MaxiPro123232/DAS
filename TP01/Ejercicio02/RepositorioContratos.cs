using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace Ejercicio02
{
    public class RepositorioContratos
    {
        private List<Contrato> contratos = new();
        public void Agregar(Contrato c) => contratos.Add(c);
        public List<Contrato> Listar() => contratos;

        public double CalcularTotalRecaudado()
        {
            return contratos.Sum(c => c.PrecioFinal);
        }

        public Paquete PaqueteMasVendido() =>
            contratos.GroupBy(c => c.Paquete)
                     .OrderByDescending(g => g.Count())
                     .FirstOrDefault()?.Key;
    }
}
