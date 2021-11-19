using System;
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
    }
}
