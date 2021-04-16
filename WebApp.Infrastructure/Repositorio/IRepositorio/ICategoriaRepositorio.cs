using EditorialMvc.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EditorialMvc.DataAccess.Repositorio.IRepositorio
{
    public interface ICategoriaRepositorio : IRepositorio<Categoria>
    {
        void Actualizar(Categoria categoria);
    }
}
