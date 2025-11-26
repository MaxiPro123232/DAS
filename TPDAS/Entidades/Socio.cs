using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Socio
    {
        public int SocioId { get; set; } 
        public string DNI { get; set; } 
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; } 

        public List<Prestamo> Prestamos { get; set; }
    }
}
