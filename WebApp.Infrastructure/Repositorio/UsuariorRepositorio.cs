﻿using EditorialMvc.DataAccess.Data;
using EditorialMvc.DataAccess.Repositorio;
using EditorialMvc.DataAccess.Repositorio.IRepositorio;
using EditorialMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorialMvc.DataAccess.Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        readonly ApplicationDbContext _db;

        public void Actualizar(Usuario usuario)
        {
            var c = _db.Usuarios.FirstOrDefault(s => s.Id == usuario.Id);

            if (c == null)
                return;

            _db.Update(usuario);
        }
    }
}
