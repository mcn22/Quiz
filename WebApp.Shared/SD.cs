using System;

namespace EditorialMvc.Utility
{
    public static class SD
    {
        public const string Proc_Cubierta_Listar = "usp_ListarCubiertas";
        public const string Proc_Cubierta_Buscar = "usp_BuscarCubierta";
        public const string Proc_Cubierta_Crear = "usp_CrearCubierta";
        public const string Proc_Cubierta_Actualizar = "usp_ActualizarCubierta";
        public const string Proc_Cubierta_Borrar = "usp_BorrarCubierta";

        public static class Roles
        {
            public const string Administrador = "Administrador";
            public const string Empleado = "Empleado";
            public const string Compania = "Compañía";
            public const string Simple = "Simple";
        }
    }
}
