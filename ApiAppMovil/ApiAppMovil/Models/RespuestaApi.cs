namespace ApiAppMovil.Models
{
    public class RespuestaApi
    {
        public string httpResponseCode { get; set; }

        public Contacto contacto { get; set; }

        public List<Contacto> listaContactos { get; set; }
    }
}
