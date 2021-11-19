using System;
using System.Data.SqlClient;
using DataLayer;
using DataLayer.Modelos;

namespace BusinessLayer
{
    public class ServiceUsuarios
    {

        private SqlConnection _conexion;
        private DataUsuarios data;
        public ServiceUsuarios(SqlConnection conexion)
        {
            _conexion = conexion;
        }

        public Usuarios Login(string Usuarios, string Contraseña)
        {
            return data.Login(Usuarios,Contraseña);
        }
    }
}
