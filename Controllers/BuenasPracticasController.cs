using Microsoft.AspNetCore.Mvc;
using ReciclajeApp.Models;
using ReciclajeApp.Repositories;

namespace ReciclajeApp.Controllers
{
    public class BuenasPracticasController : Controller
    {
        private readonly IBuenaPracticaRepository _buenaPracticaRepository;

        public BuenasPracticasController(IBuenaPracticaRepository buenaPracticaRepository)
        {
            _buenaPracticaRepository = buenaPracticaRepository;
        }

        // Acción para la página principal de Buenas Prácticas
        public IActionResult Practicas(string clasificacionDesecho)
        {
            // Obtener las buenas prácticas filtradas por la clasificación de desecho (si existe)
            var practicas = _buenaPracticaRepository.ObtenerBuenasPracticasPorTipoDesecho(clasificacionDesecho);
            return View(practicas);
        }

        // Acción para la vista de contacto, si la necesitas en este controlador
        public IActionResult Contacto()
        {
            return View();
        }
    }
}