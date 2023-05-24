using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;


namespace ApiAppMovil.Models
{
    public class Contacto
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string imagen { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string cedula { get; set; }
    }
}
