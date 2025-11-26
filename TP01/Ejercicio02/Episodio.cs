using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace Ejercicio02
{
    public class Episodio
    {
        public string Titulo { get; set; }
        public int DuracionMin { get; set; }

        public Episodio(string titulo, int duracion)
        {
            Titulo = titulo;
            DuracionMin = duracion;
        }

        public override string ToString() => $"{Titulo} ({DuracionMin} min)";
    }
}
