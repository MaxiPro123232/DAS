using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;



namespace Ejercicio02
{
    public class Cliente
    {
        public int CodigoCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public int Edad
        {
            get
            {
                int e = DateTime.Today.Year - FechaNacimiento.Year;
                if (FechaNacimiento.Date > DateTime.Today.AddYears(-e)) e--;
                return e;
            }
        }

        public Cliente(int codigo, string nombre, string apellido, string dni, DateTime fechaNac)
        {
            CodigoCliente = codigo;
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            FechaNacimiento = fechaNac;
        }

        public override string ToString() => $"{CodigoCliente} - {Nombre} {Apellido}";
    }
}
