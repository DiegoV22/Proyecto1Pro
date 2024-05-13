using System.ComponentModel.DataAnnotations;

namespace Proyecto1Pro.Models
{
    public class Usuario
    {
        [Key] public int IdUsuario { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
    }
}
