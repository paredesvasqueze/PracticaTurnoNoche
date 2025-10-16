using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class DocentesController : Controller
    {
        private readonly IDocentesService _service;

        public DocentesController(IDocentesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var docentes = await _service.GetAllAsync();
            return View(docentes);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Docentes docente)
        {
            if (!ModelState.IsValid)
                return View(docente);

            await _service.AddAsync(docente);
            TempData["Success"] = "Docente registrado correctamente.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var docente = await _service.GetByIdAsync(id);
            if (docente == null) return NotFound();
            return View(docente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Docentes docente)
        {
            if (!ModelState.IsValid)
                return View(docente);

            await _service.UpdateAsync(docente);
            TempData["Success"] = "Datos del docente actualizados correctamente.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var docente = await _service.GetByIdAsync(id);
            if (docente == null) return NotFound();
            return View(docente);
        }

        // POST: Docentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            TempData["Success"] = "Docente eliminado correctamente.";
            return RedirectToAction(nameof(Index));
        }
    }
}
