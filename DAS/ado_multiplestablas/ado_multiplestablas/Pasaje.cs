using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ado_multiplestablas
{
    public class Pasaje
    {
        public int IdPasaje { get; set; }
        public string NumeroAsiento { get; set; }
        public DateTime FechaVuelo { get; set; }
        public Avion IdAvion { get; set; }
        public Pasajero IdPasajero { get; set; }
    }
}
