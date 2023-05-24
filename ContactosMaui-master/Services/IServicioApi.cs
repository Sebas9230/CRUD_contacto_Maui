using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactosMaui.Models;

namespace ContactosMaui.Services
{
    public interface IServicioApi
    {
        public Task<List<Contacto>> ListarContactos();
        public Task<Contacto> ObtenerContacto(int id);
        public Task<string> GuardarContacto(Contacto contacto);
        public Task<string> EditarContacto(int id, Contacto contacto);
        public Task<string> BorrarContacto(int id);
    }
}
