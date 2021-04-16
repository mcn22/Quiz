using System;
using System.Collections.Generic;
using System.Text;

namespace EditorialMvc.DataAccess.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        ICategoriaRepositorio Categorias { get; }

        IUsuarioRepositorio Usuarios { get; }

        void Guardar();
    }
}
