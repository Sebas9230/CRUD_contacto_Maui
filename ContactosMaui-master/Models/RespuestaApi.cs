using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactosMaui.Models
{
    internal class RespuestaApi
    {
        public string httpResponseCode { get; set; }

        public Contacto contacto { get; set; }

        public List<Contacto> listaContactos { get; set; }
    }
}
