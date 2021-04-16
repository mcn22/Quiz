using EditorialMvc.DataAccess.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain;

namespace EditorialMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PensamientoController : Controller
    {
        public PensamientoController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        readonly IUnidadTrabajo _unidadTrabajo;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null)
            {
                return View(new Pensamiento());
            }
            else
            {
                Pensamiento Pensamiento = _unidadTrabajo.Pensamientos.Buscar(id.GetValueOrDefault());
                if (Pensamiento == null)
                {
                    return NotFound();
                }

                return View(Pensamiento);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Pensamiento Pensamiento)
        {
            if (ModelState.IsValid)
            {
                if (Pensamiento.Id != 0)
                {
                    _unidadTrabajo.Pensamientos.Actualizar(Pensamiento);
                }
                else
                {
                    _unidadTrabajo.Pensamientos.Agregar(Pensamiento);
                }
                _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }

            return View(Pensamiento);
        }

        #region Api Methods

        [HttpDelete]
        public IActionResult Borrar(int id)
        {
            var Pensamiento = _unidadTrabajo.Pensamientos.Buscar(id);

            if (Pensamiento == null)
            {
                return Json(new { success = false, message = "Se ha producido un error mientras se borraba." });
            }

            _unidadTrabajo.Pensamientos.Remover(Pensamiento);
            _unidadTrabajo.Guardar();

            return Json(new { success = true, message = "El pensamiento se ha borrado permanentemente." });
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Json(new { data = _unidadTrabajo.Pensamientos.Listar()});
        }

        #endregion
    }
}
