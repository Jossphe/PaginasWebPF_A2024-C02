using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReciclajeApp.Models
{
    public class Testimonio
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la empresa es requerido")]
        [StringLength(100)]
        public string Empresa { get; set; }

        [Required(ErrorMessage = "El mensaje es requerido")]
        [StringLength(500)]
        public string Mensaje { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }

        public bool Activo { get; set; }
    }
}
