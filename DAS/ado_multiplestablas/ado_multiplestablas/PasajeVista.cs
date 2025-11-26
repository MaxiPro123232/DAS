using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ado_multiplestablas
{
    public class PasajeVista
    {
        public int IdPasaje { get; set; }
        public string NumeroAsiento { get; set; }
        public DateTime FechaVuelo { get; set; }
        public int IdAvion { get; set; }
        public string MatriculaAvion { get; set; }
        public int IdPasajero { get; set; }
        public string NombrePasajero { get; set; }
    }
}
