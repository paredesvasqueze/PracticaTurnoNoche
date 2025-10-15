using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class ColegioController : Controller
    {
        private readonly IColegioService _service;

        public ColegioController(IColegioService service)
        {
            _service = service;
        }

        // GET: ColegioController
        public async Task<IActionResult> Index()
        {
            var colegios = await _service.GetAllAsync();
            return View(colegios);
        }

        // GET: ColegioController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var colegio = await _service.GetByIdAsync(id);
            if (colegio == null) return NotFound();
            return View(colegio);
        }

        // GET: ColegioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColegioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Colegio colegio)
        {
            if (!ModelState.IsValid)
                return View(colegio);

            await _service.AddAsync(colegio);
            return RedirectToAction(nameof(Index));
        }

        // GET: ColegioController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var colegio = await _service.GetByIdAsync(id);
            if (colegio == null) return NotFound();
            return View(colegio);
        }

        // POST: ColegioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Colegio colegio)
        {
            if (!ModelState.IsValid)
                return View(colegio);

            await _service.UpdateAsync(colegio);
            return RedirectToAction(nameof(Index));
        }

        // GET: ColegioController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            // Opcional: mostrar confirmación con la entidad
            var colegio = await _service.GetByIdAsync(id);
            if (colegio == null) return NotFound();
            return View(colegio);
        }

        // POST: ColegioController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
