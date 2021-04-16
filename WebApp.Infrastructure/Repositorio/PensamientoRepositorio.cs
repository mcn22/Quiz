using EditorialMvc.DataAccess.Data;
using EditorialMvc.DataAccess.Repositorio;
using EditorialMvc.DataAccess.Repositorio.IRepositorio;
using EditorialMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApp.Domain;

namespace EditorialMvc.DataAccess.Repositorio
{
    public class PensamientoRepositorio : Repositorio<Pensamiento>, IPensamientoRepositorio
    {
        public PensamientoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        readonly ApplicationDbContext _db;

        public void Actualizar(Pensamiento Pensamiento)
        {
            var c = _db.Pensamientos.FirstOrDefault(s => s.Id == Pensamiento.Id);

            if (c == null)
                return;

            c.Titulo = Pensamiento.Titulo;
            c.Contenido = Pensamiento.Contenido;
            c.Fecha = Pensamiento.Fecha;
            c.Imagen = Pensamiento.Imagen;
            c.Autor = Pensamiento.Autor;

        }
    }
}
