using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Web.Controllers
{
    public class GradoController : Controller
    {
        private readonly IGradoService _service;

        public GradoController(IGradoService service)
        {
            _service = service;
        }

        // GET: Grado
        public async Task<IActionResult> Index()
        {
            var grados = await _service.GetAllAsync();
            return View(grados);
        }

        // GET: Grado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grado/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Grado grado)
        {
            if (!ModelState.IsValid)
                return View(grado);

            await _service.AddAsync(grado);
            return RedirectToAction(nameof(Index));
        }

        // GET: Grado/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var grado = await _service.GetByIdAsync(id);
            if (grado == null)
                return NotFound();

            return View(grado);
        }

        // POST: Grado/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Grado grado)
        {
            if (!ModelState.IsValid)
                return View(grado);

            await _service.UpdateAsync(grado);
            return RedirectToAction(nameof(Index));
        }

        // GET: Grado/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var grado = await _service.GetByIdAsync(id);
            if (grado == null)
                return NotFound();

            return View(grado);
        }

        // POST: Grado/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

