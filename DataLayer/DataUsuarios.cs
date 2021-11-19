using System;
using System.Data.SqlClient;
using DataLayer.Modelos;

namespace DataLayer
{
    public class DataUsuarios
    {
        private SqlConnection _conexion;
        public DataUsuarios(SqlConnection conexion)
        {
            _conexion = conexion;
        }
        public Usuarios Login(string Usuario, string Contraseña)
        {
            try
            {
                SqlCommand comando = new SqlCommand("SP_Login",_conexion);

                comando.Parameters.AddWithValue("@Usuario", Usuario);
                comando.Parameters.AddWithValue("@Contraseña",Contraseña);

                Usuarios datos = new Usuarios();

                SqlDataReader LeerDatos = comando.ExecuteReader();

                if (LeerDatos.Read())
                {
                    datos.Id = LeerDatos.IsDBNull(0) ? 0 : LeerDatos.GetInt32(0);
                    datos.Nombre = LeerDatos.IsDBNull(1) ? "" : LeerDatos.GetString(1);
                }

                return datos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
