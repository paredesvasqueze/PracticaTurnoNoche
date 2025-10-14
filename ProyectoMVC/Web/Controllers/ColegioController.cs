using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ColegioController : Controller
    {
        // GET: ColegioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ColegioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ColegioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColegioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ColegioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ColegioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ColegioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ColegioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
