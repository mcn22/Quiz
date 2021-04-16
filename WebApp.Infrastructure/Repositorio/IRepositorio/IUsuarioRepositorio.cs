using EditorialMvc.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EditorialMvc.DataAccess.Repositorio.IRepositorio
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        void Actualizar(Usuario categoria);
    }
}
