using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReciclajeApp.Models
{
    public class PreguntaFrecuente
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
    }
}
