using Microsoft.AspNetCore.Mvc;
using ReciclajeApp.Models;
using ReciclajeApp.Repositories;

namespace ReciclajeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestimonioRepository _testimonioRepository;

        public HomeController(ITestimonioRepository testimonioRepository)
        {
            _testimonioRepository = testimonioRepository;
        }

        public IActionResult Index()
        {
            var testimonios = _testimonioRepository.ObtenerTestimoniosActivos();
            return View(testimonios);
        }

        public IActionResult Contacto()
        {
            return View();
        }
    }
}
