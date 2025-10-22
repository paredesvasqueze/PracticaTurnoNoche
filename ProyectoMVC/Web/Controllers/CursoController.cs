using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class CursoController : Controller
    {
        private readonly ICursoService _service;
        public CursoController(ICursoService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var cursos = await _service.GetAllAsync();
            ViewData["Title"] = "Listado de Cursos";
            return View(cursos);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Crear Curso";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Curso curso)
        {
            if (!ModelState.IsValid) return View(curso);

            await _service.AddAsync(curso);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var curso = await _service.GetByIdAsync(id);
            if (curso == null) return NotFound();
            ViewData["Title"] = "Editar Curso";
            return View(curso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Curso curso)
        {
            if (!ModelState.IsValid) return View(curso);

            await _service.UpdateAsync(curso);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
