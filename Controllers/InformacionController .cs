using Microsoft.AspNetCore.Mvc;
using ReciclajeApp.Models;
using ReciclajeApp.Repositories;

namespace ReciclajeApp.Controllers
{
    public class InformacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InformacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var preguntas = _context.PreguntasFrecuentes.ToList();
            var documentos = _context.Documentos.ToList();


            ViewData["Preguntas"] = preguntas;
            ViewData["Documentos"] = documentos;

            return View();
        }
        public IActionResult InformacionG()
        {
            return View();
        }
    }
}

