using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Web.Controllers
{
    public class ProductoAjaxController : Controller
    {
        private readonly IProductoService _service;

        public ProductoAjaxController(IProductoService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var productos = await _service.GetAllAsync();
            return View(productos);
        }

        [HttpGet]
        public async Task<IActionResult> Form(int? id)
        {
            // Poblar ViewBag.Categorias para que el partial tenga opciones
            ViewBag.Categorias = (await _service.GetCategoriaAllAsync())?.ToList() ?? new List<Categoria>();

            if (id == null || id == 0)
                return PartialView("_FormularioProducto", new Producto());
            var producto = await _service.GetByIdAsync(id.Value);
            if (producto == null) return NotFound();
            return PartialView("_FormularioProducto", producto);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] Producto producto)
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



                if (producto.Id == 0)
                    await _service.AddAsync(producto);
                else
                    await _service.UpdateAsync(producto);

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
