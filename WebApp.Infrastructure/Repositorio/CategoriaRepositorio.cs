using EditorialMvc.DataAccess.Data;
using EditorialMvc.DataAccess.Repositorio;
using EditorialMvc.DataAccess.Repositorio.IRepositorio;
using EditorialMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorialMvc.DataAccess.Repositorio
{
    public class CategoriaRepositorio : Repositorio<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        readonly ApplicationDbContext _db;

        public void Actualizar(Categoria categoria)
        {
            var c = _db.Categorias.FirstOrDefault(s => s.Id == categoria.Id);

            if (c == null)
                return;

            c.Nombre = categoria.Nombre;
        }
    }
}
