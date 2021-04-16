using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Domain;

namespace EditorialMvc.DataAccess.Repositorio.IRepositorio
{
    public interface IPensamientoRepositorio : IRepositorio<Pensamiento>
    {
        void Actualizar(Pensamiento Pensamiento);
    }
}
