using EditorialMvc.DataAccess.Data;
using EditorialMvc.DataAccess.Repositorio;
using EditorialMvc.DataAccess.Repositorio.IRepositorio;
using EditorialMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditorialMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsuarioController : Controller
    {
        public UsuarioController(ApplicationDbContext db)
        {
            _db = db;
        }

        readonly ApplicationDbContext _db;

        public IActionResult Index()
        {
            return View();
        }

        #region Api Methods

        [HttpPost]
        public IActionResult LockUnlock([FromBody]string id)
        {
            var usuario = _db.Usuarios.FirstOrDefault(s=>s.Id == id);

            if (usuario == null)
            {
                return Json(new { success = false, message = "Se ha producido un error mientras se bloqueaba/desbloqueaba." });
            }

            if (usuario.LockoutEnd != null && usuario.LockoutEnd > DateTime.Now)
            {
                usuario.LockoutEnd = null;
            }
            else
            {
                usuario.LockoutEnd = DateTime.Now.AddYears(1000);
            }

            _db.SaveChanges();
            return Json(new { success = true, message = "El usuario se ha bloqueado/desbloqueado." });
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var usuarios = _db.Usuarios.ToList();
            var userRoles = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();

            usuarios.ForEach
                (
                    usuario =>
                    {
                        var roleId = userRoles.FirstOrDefault(s => s.UserId == usuario.Id).RoleId;
                        //usuario.Role = roles.FirstOrDefault(s => s.Id == roleId).Name;

                        //if (usuario.Compania == null)
                        //{
                        //    usuario.Compania = new Compania { Nombre = string.Empty };
                        //}
                    }
                );

            return Json(new { data = usuarios });
        }

        #endregion
    }
}
