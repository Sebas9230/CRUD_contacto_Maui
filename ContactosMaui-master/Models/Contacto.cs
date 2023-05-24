using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactosMaui.Models
{
    public class Contacto
    {
        public int id { get; set; }
        public string imagen { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string cedula { get; set; }

    }
}
