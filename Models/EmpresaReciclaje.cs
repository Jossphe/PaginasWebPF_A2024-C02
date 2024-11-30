using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReciclajeApp.Models
{
    public class EmpresaReciclaje
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreEmpresa { get; set; }

        [Required]
        [StringLength(100)]
        public string TipoDesechos { get; set; }

        [Required]
        public int CantidadDesechos { get; set; }

        public string? NombreResponsable { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Telefono { get; set; }

        [Required]
        public bool TieneProgramaReciclaje { get; set; }

        [StringLength(500)]
        public string? TipoResiduos { get; set; }

        [StringLength(500)]
        public string? ObjetivoReciclaje { get; set; }

        [Required]
        public bool UsaCertificadoReciclaje { get; set; }

        [Required]
        public DateTime FechaInicioPrograma { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
