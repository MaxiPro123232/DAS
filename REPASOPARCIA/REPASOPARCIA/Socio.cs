using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPASOPARCIA
{
    public class Socio
    {
        public int Id { get; set; }
        public string nombre {  get; set; }
        public string apellido { get; set; }
        public string DNI { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int NumSocio { get; set; }
        public bool CuotaAlDia { get; set; }
    }
}
