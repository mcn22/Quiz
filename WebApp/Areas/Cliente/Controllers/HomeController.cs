using EditorialMvc.DataAccess.Repositorio.IRepositorio;
using EditorialMvc.Models;
using EditorialMvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EditorialMvc.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {
        public HomeController(ILogger<HomeController> logger, IUnidadTrabajo unidadTrabajo)
        {
            _logger = logger;
            _unidadTrabajo = unidadTrabajo;
        }

        private readonly ILogger<HomeController> _logger;
        readonly IUnidadTrabajo _unidadTrabajo;


        public IActionResult Index()
        {
            IEnumerable<Usuario> libros = _unidadTrabajo.Usuarios.Listar();
            return View(libros);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
