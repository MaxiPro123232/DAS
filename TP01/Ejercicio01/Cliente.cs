using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class Cliente
    {
        public string Dni { get; }
        public string NombreApellido { get; private set; }
        public string Telefono { get; private set; }
        public string Email { get; private set; }
        public DateTime FechaNacimiento { get; private set; }

        public int Edad
        {
            get
            {
                var hoy = DateTime.Today;
                int edad = hoy.Year - FechaNacimiento.Year;
                if (FechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
                return edad;
            }
        }

        public Cliente(string dni, string nombreApellido, string telefono, string email, DateTime fechaNacimiento)
        {
            if (string.IsNullOrWhiteSpace(dni)) throw new ArgumentException("DNI obligatorio.");
            if (string.IsNullOrWhiteSpace(nombreApellido)) throw new ArgumentException("Nombre y apellido obligatorio.");
            if (string.IsNullOrWhiteSpace(telefono)) throw new ArgumentException("Teléfono obligatorio.");
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email obligatorio.");

            Dni = dni.Trim();
            NombreApellido = nombreApellido.Trim();
            Telefono = telefono.Trim();
            Email = email.Trim();
            FechaNacimiento = fechaNacimiento;
        }

        public void ModificarDatos(string nombreApellido, string telefono, string email, DateTime fechaNacimiento)
        {
            if (string.IsNullOrWhiteSpace(nombreApellido)) throw new ArgumentException("Nombre y apellido obligatorio.");
            if (string.IsNullOrWhiteSpace(telefono)) throw new ArgumentException("Teléfono obligatorio.");
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email obligatorio.");

            NombreApellido = nombreApellido.Trim();
            Telefono = telefono.Trim();
            Email = email.Trim();
            FechaNacimiento = fechaNacimiento;
        }
    }
}
    