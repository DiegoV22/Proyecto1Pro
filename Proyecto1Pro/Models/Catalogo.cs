using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto1Pro.Models
{
    public class Catalogo
    {
        [Key]
        public int IdCatalogo { get; set; }
        [Required]
        [ForeignKey("Peluche")]
        public int? IdPeluche { get; set; }
        public Peluche? Peluche { get; set; }
    }
}
