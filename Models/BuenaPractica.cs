using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReciclajeApp.Models
{
    public class BuenaPractica
    {
        [Key]
        public int PracticaID { get; set; }

        [Required(ErrorMessage = "El título es requerido")]
        [StringLength(200, ErrorMessage = "El título no puede exceder los 200 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La clasificación de desecho es requerida")]
        [StringLength(100, ErrorMessage = "La clasificación de desecho no puede exceder los 100 caracteres")]
        public string ClasificacionDesecho { get; set; }  // Manteniendo "ClasificacionDesecho"

        [Column(TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime? FechaActualizacion { get; set; }
    }
}