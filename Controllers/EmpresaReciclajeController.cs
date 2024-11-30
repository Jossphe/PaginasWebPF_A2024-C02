using Microsoft.AspNetCore.Mvc;
using ReciclajeApp.Models;
using ReciclajeApp.Repositories;

namespace ReciclajeApp.Controllers
{
    public class EmpresaReciclajeController : Controller
    {
        private readonly IEmpresaReciclajeRepository _empresaReciclajeRepository;

        public EmpresaReciclajeController(IEmpresaReciclajeRepository empresaReciclajeRepository)
        {
            _empresaReciclajeRepository = empresaReciclajeRepository;
        }

        // Acción para mostrar la página principal del reciclaje
        public async Task<IActionResult> Index()
        {
            var empresas = await _empresaReciclajeRepository.ObtenerEmpresasReciclajeAsync();
            return View(empresas);
        }

        // Acción para mostrar el formulario de creación
        public IActionResult Crear()
        {
            return View();
        }

        // Acción para guardar la información de la empresa
        [HttpPost]
        public async Task<IActionResult> Crear(EmpresaReciclaje empresa)
        {
            if (ModelState.IsValid)
            {
                await _empresaReciclajeRepository.CrearEmpresaReciclajeAsync(empresa);
                return RedirectToAction(nameof(Crear));
            }

            return View(empresa);
        }
    }
}
