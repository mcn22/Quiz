using System;
using System.Collections.Generic;
using System.Text;

namespace EditorialMvc.DataAccess.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        ICategoriaRepositorio Categorias { get; }

        IUsuarioRepositorio Usuarios { get; }

        IPensamientoRepositorio Pensamientos { get; }

        void Guardar();
    }
}
