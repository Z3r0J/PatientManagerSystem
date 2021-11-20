using System;
using System.Data;
using System.Data.SqlClient;
using DataLayer;
using DataLayer.Modelos;

namespace BusinessLayer
{
    public class ServiceUsuarios
    {

        private DataUsuarios data;
        public ServiceUsuarios(SqlConnection _conexion)
        {
            data = new DataUsuarios(_conexion);
        }
        public Usuarios Login(string Usuarios, string Contraseña)
        {
            return data.Login(Usuarios,Contraseña);
        }
        public bool Agregar(Usuarios item)
        {
            return data.Agregar(item);
        }
        public bool Actualizar(Usuarios item)
        {

            return data.Actualizar(item);
        }
        public bool Eliminar(Usuarios item)
        {
            return data.Eliminar(item);
        }
        public Usuarios SeleccionCorreo(decimal Id)
        {
            return data.SeleccionCorreo(Id);
        }

        public DataTable ListadoUsuarios()
        {
            return data.ListarUsuarios();
        }
    }
}
