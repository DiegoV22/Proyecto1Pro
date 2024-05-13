using System.ComponentModel.DataAnnotations;

namespace Proyecto1Pro.Models
{
    public class Peluche
    {
        [Key]
        public int IdPeluche { get; set; }
        [Required]
        public string NombreP { get; set; }  
        public float Precio { get; set; }
        public int Tamano { get; set; }
        public string Categoria { get; set; }
    }
}
