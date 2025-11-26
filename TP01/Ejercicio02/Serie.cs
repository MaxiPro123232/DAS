using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace Ejercicio02
{
    public class Serie
    {
        public string Titulo { get; set; }
        public int Temporadas { get; set; }
        public List<Episodio> Episodios { get; set; } = new();
        public int DuracionPromedio { get; set; }
        public double Ranking { get; set; }
        public GeneroSerie Genero { get; set; }
        public string Director { get; set; }

        public Serie(string titulo, double ranking, GeneroSerie genero)
        {
            Titulo = titulo;
            Ranking = ranking;
            Genero = genero;
            Temporadas = 0;         
            DuracionPromedio = 0; 
        }
        public Serie(string titulo, int temporadas, int duracionPromedio, double ranking, GeneroSerie genero, string director)
        {
            Titulo = titulo;
            Temporadas = temporadas;
            DuracionPromedio = duracionPromedio;
            Ranking = ranking;
            Genero = genero;
            Director = director;
        }

        public override string ToString() => $"{Titulo} ({Genero}, Rank {Ranking})";
    }
}
