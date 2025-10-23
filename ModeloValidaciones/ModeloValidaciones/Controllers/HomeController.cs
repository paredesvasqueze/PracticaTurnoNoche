using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ModeloValidaciones.Models;

namespace ModeloValidaciones.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Crear()
        {
            // Redirige al formulario en Index para evitar buscar una vista 'Crear' que no existe.
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Crear(Producto producto)
        {
            if (ModelState.IsValid)
            {
                // Aquí se guardaría el producto en la BD...
                ViewBag.Mensaje = "Producto guardado correctamente";

                // Limpiar el ModelState y volver al formulario (Index) con un modelo vacío
                ModelState.Clear();
                return View("Index", new Producto());
            }

            // Si hay errores de validación, devolver el formulario con el modelo para mostrar errores
            return View("Index", producto);
        }
    }
}
