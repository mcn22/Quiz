using EditorialMvc.DataAccess.Repositorio;
using EditorialMvc.DataAccess.Repositorio.IRepositorio;
using EditorialMvc.Models;
using EditorialMvc.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditorialMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Roles.Administrador + "," + SD.Roles.Empleado)]
    public class CategoriaController : Controller
    {
        public CategoriaController(IUnidadTrabajo unidadTrabajo)
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
                // Create
                return View(new Categoria());
            }
            else
            {
                // Edit
                Categoria categoria = _unidadTrabajo.Categorias.Buscar(id.GetValueOrDefault());
                if (categoria == null)
                {
                    return NotFound();
                }

                return View(categoria);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (categoria.Id != 0)
                {
                    _unidadTrabajo.Categorias.Actualizar(categoria);
                }
                else
                {
                    _unidadTrabajo.Categorias.Agregar(categoria);
                }
                _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        #region Api Methods

        [HttpDelete]
        public IActionResult Borrar(int id)
        {
            var categoria = _unidadTrabajo.Categorias.Buscar(id);

            if (categoria == null)
            {
                return Json(new { success = false, message = "Se ha producido un error mientras se borraba." });
            }

            _unidadTrabajo.Categorias.Remover(categoria);
            _unidadTrabajo.Guardar();

            return Json(new { success = true, message = "El registro se ha borrado permanentemente." });
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Json(new { data = _unidadTrabajo.Categorias.Listar() });
        }

        #endregion
    }
}
