using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto1Pro.Models
{
    public class Compra
    {
        [Key]
        public int IdCompra { get; set; }

        [Required]
        public DateTime FechaCompra { get; set; }
        public string MetodoPago { get; set; }

        [ForeignKey("Usuario")]
        public int? IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }

        [ForeignKey("Peluche")]
        public int? IdPeluche { get; set; }
        public Peluche? Peluche { get; set; }
    }
}
