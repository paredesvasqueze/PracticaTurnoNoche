using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class DocentesAjaxController : Controller
    {
        private readonly IDocentesService _service;

        public DocentesAjaxController(IDocentesService service)
        {
            _service = service;
        }

        // Lista de docentes para la vista principal
        public async Task<IActionResult> Index()
        {
            var docentes = await _service.GetAllAsync();
            return View(docentes);
        }

        // Formulario para crear o editar docente
        [HttpGet]
        public async Task<IActionResult> Form(int? id)
        {
            if (id == null || id == 0)
                return PartialView("_FormularioDocente", new Docentes());
            else
            {
                var docente = await _service.GetByIdAsync(id.Value);
                return PartialView("_FormularioDocente", docente);
            }
        }

        // Guardar docente (insertar o actualizar)
        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] Docentes docente)
        {
            if (!ModelState.IsValid)
            {
                string errors = "";
                foreach (var state in ModelState.Values)
                    foreach (var error in state.Errors)
                        errors += error.ErrorMessage + " ";

                return Json(new { success = false, message = errors });
            }

            if (docente.IdDocente == 0)
                await _service.AddAsync(docente);
            else
                await _service.UpdateAsync(docente);

            return Json(new { success = true });
        }

        // Eliminar docente
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Json(new { success = true });
            }
            catch (System.Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
