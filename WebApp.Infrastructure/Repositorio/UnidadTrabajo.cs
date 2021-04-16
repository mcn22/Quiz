using EditorialMvc.DataAccess.Data;
using EditorialMvc.DataAccess.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace EditorialMvc.DataAccess.Repositorio
{
    public class UnidadTrabajo: IUnidadTrabajo
    {
        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;

            Categorias = new CategoriaRepositorio(db);
            Pensamientos = new PensamientoRepositorio(db);
            Usuarios = new UsuarioRepositorio(db);
        }

        readonly ApplicationDbContext _db;

        public ICategoriaRepositorio Categorias { get; private set; }

        public IPensamientoRepositorio Pensamientos { get; private set; }

        public IUsuarioRepositorio Usuarios { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Guardar() 
        {
            _db.SaveChanges();
        }
    }
}
