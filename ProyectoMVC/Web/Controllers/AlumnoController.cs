using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace ProyectoColegio.Controllers
{
    public class AlumnoController : Controller
    {
        private readonly IAlumnoService _alumnoService;

        public AlumnoController(IAlumnoService alumnoService)
        {
            _alumnoService = alumnoService;
        }

        public async Task<IActionResult> Index()
        {
            var alumnos = await _alumnoService.GetAllAsync();
            return View(alumnos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Alumno alumno)
        {
            if (!ModelState.IsValid)
                return View(alumno);

            await _alumnoService.AddAsync(alumno);
            return RedirectToAction(nameof(Index));
        }
    }
}
