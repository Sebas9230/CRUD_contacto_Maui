using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactosMaui.Models;
using System.Net;
using Microsoft.VisualBasic;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ContactosMaui.Services
{
    public class ServicioApi : IServicioApi
    {
        private static string _baseUrl;

        public ServicioApi()
        {
            _baseUrl = "http://10.0.2.2:5099/";
        }


        public async Task<List<Contacto>> ListarContactos()
        {
            List<Contacto> productos = new List<Contacto>();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync("api/Contactos");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<RespuestaApi>(json_response);
                productos = resultado.listaContactos;
            }
            return productos;
        }


        public async Task<Contacto> ObtenerContacto(int id)
        {
            Contacto contacto = new Contacto();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync($"api/Contactos/{id}"); //esto se ve en swagger
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<RespuestaApi>(json_response);
                contacto = resultado.contacto;
            }
            return contacto;
        }

        public async Task<string> GuardarContacto(Contacto contacto)
        {
            string httpsResponseCode = HttpStatusCode.BadRequest.ToString();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(contacto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("/api/v1/PetShop/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<RespuestaApi>(json_response);
                httpsResponseCode = resultado.httpResponseCode;
            }
            return httpsResponseCode;
        }

        public async Task<string> BorrarContacto(int id)
        {
            string httpsResponseCode = HttpStatusCode.BadRequest.ToString();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.DeleteAsync($"api/Contactos/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<RespuestaApi>(json_response);
                httpsResponseCode = resultado.httpResponseCode;
            }
            return httpsResponseCode;
        }

        public async Task<string> EditarContacto(int id, Contacto contacto)
        {
            string httpsResponseCode = HttpStatusCode.BadRequest.ToString();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(contacto), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"api/Contactos/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<RespuestaApi>(json_response);
                httpsResponseCode = resultado.httpResponseCode;
            }
            return httpsResponseCode;
        }
    }
}
