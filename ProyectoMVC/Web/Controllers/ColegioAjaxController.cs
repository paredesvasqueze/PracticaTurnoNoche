using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class ColegioAjaxController : Controller
    {
        private readonly IColegioService _service;

        public ColegioAjaxController(IColegioService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var colegios = await _service.GetAllAsync();
            return View(colegios);
        }

        [HttpGet]
        public async Task<IActionResult> Form(int? id)
        {
            if (id == null || id == 0)
                return PartialView("_FormularioColegio", new Colegio());
            else
            {
                var colegio = await _service.GetByIdAsync(id.Value);
                return PartialView("_FormularioColegio", colegio);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] Colegio colegio)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var cMensaje = "";
                    foreach (var item in ModelState)
                    {
                        var field = item.Key;
                        var errors = item.Value.Errors;
                        foreach (var error in errors)
                        {
                            cMensaje = cMensaje + " " + error.ErrorMessage + "\n";
                        }
                    }

                    return Json(new { success = false, message = cMensaje });
                }

                if (colegio.IdColegio == 0)
                    await _service.AddAsync(colegio);
                else
                    await _service.UpdateAsync(colegio);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
