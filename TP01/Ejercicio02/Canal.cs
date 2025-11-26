using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace Ejercicio02
{
    public class Canal
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool EsExclusivo { get; set; }
        public List<Serie> Series { get; set; } = new();

        public Canal(string codigo, string nombre, bool esExclusivo)
        {
            Codigo = codigo;
            Nombre = nombre;
            EsExclusivo = esExclusivo;
        }

        public override string ToString() => $"{Nombre}{(EsExclusivo ? " [Exclusivo]" : "")}";
    }
}

