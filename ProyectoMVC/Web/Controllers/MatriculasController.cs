using Microsoft.AspNetCore.Mvc;
using SistemaColegio.Data;
using SistemaColegio.Models;
using SistemaColegioMVC.Data;
using SistemaColegioMVC.Models;

namespace SistemaColegioMVC.Controllers
{
    public class MatriculasController : Controller
    {
        private readonly ColegioContext _context;

        public MatriculasController(ColegioContext context)
        {
            _context = context;
        }

        // GET: Matriculas
        public IActionResult Index()
        {
            var matriculas = _context.Matriculas.ToList();
            return View(matriculas);
        }

        // GET: Matriculas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Matriculas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                _context.Matriculas.Add(matricula);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(matricula);
        }
    }
}
