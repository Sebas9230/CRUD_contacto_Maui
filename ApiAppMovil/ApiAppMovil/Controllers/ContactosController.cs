using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAppMovil.Context;
using ApiAppMovil.Models;
using System.Net;

namespace ApiAppMovil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : ControllerBase
    {

        private readonly ApplicationDbContext _db;
        protected RespuestaApi _resultadoApi;



        public ContactosController(ApplicationDbContext db)
        {
            _db = db;
            _resultadoApi = new();
        }

        // GET: api/Contactos
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {

            var contactos = await _db.contactos.ToListAsync();


            if (contactos != null)
            {
                _resultadoApi.listaContactos = contactos;
                _resultadoApi.httpResponseCode = HttpStatusCode.OK.ToString();
                return Ok(_resultadoApi);
            }
            else
            {
                _resultadoApi.httpResponseCode = HttpStatusCode.BadRequest.ToString();
                return BadRequest(_resultadoApi);
            }

            return Ok(_resultadoApi);
        }



        // GET: api/Contactos/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            Contacto contacto = await _db.contactos.FirstOrDefaultAsync(x => x.id.Equals(id));
            if (contacto != null)
            {
                _resultadoApi.contacto = contacto;
                _resultadoApi.httpResponseCode = HttpStatusCode.OK.ToString();
                return Ok(_resultadoApi);
            }
            else
            {
                _resultadoApi.httpResponseCode = HttpStatusCode.BadRequest.ToString();
                return BadRequest(_resultadoApi);
            }

        }


        // PUT: api/Contactos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Contacto contacto)
        {
            Contacto contacto1 = await _db.contactos.FirstOrDefaultAsync(x => x.id.Equals(id));

            if (contacto1 != null)
            {

                contacto1.imagen = contacto.imagen != null ? contacto.imagen : contacto1.imagen;
                contacto1.nombre = contacto.nombre != null ? contacto.nombre : contacto1.nombre;
                contacto1.direccion = contacto.direccion != null ? contacto.direccion : contacto1.direccion;
                contacto1.telefono = contacto.telefono != null ? contacto.telefono : contacto1.telefono;
                contacto1.cedula = contacto.cedula != null ? contacto.cedula : contacto1.cedula;

                _db.Update(contacto1);
                await _db.SaveChangesAsync();
                _resultadoApi.httpResponseCode = HttpStatusCode.OK.ToString();
                return Ok(_resultadoApi);
            }
            else
            {
                _resultadoApi.httpResponseCode = HttpStatusCode.BadRequest.ToString();
                return BadRequest(_resultadoApi);
            }



        }


        // POST: api/Contactos
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contacto contacto)
        {
            //Producto producto1 = Utils.Util.productos.Find(x => x.codigo.Equals(producto.codigo));
            Contacto contacto1 = await _db.contactos.FirstOrDefaultAsync(x => x.id.Equals(contacto.id));
            if (contacto1 == null)
            {
                await _db.contactos.AddAsync(contacto);
                await _db.SaveChangesAsync();
                _resultadoApi.httpResponseCode = HttpStatusCode.OK.ToString();
                return Ok(_resultadoApi);
            }
            else
            {
                _resultadoApi.httpResponseCode = HttpStatusCode.BadRequest.ToString();
                return BadRequest(_resultadoApi);
            }

        }


        // DELETE: api/PetShop/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Contacto contacto1 = await _db.contactos.FirstOrDefaultAsync(x => x.id.Equals(id));
            if (contacto1 != null)
            {
                _db.contactos.Remove(contacto1);
                await _db.SaveChangesAsync();
                //Utils.Util.productos.Remove(producto1);
                _resultadoApi.httpResponseCode = HttpStatusCode.OK.ToString();
                return Ok(_resultadoApi);
            }
            else
            {
                _resultadoApi.httpResponseCode = HttpStatusCode.BadRequest.ToString();
                return BadRequest(_resultadoApi);
            }
        }
    }
}
