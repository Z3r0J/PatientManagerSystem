using System;
using System.Data;
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
                _conexion.Open();
                SqlCommand comando = new SqlCommand("SP_Login",_conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Usuario", Usuario);
                comando.Parameters.AddWithValue("@Contraseña",Contraseña);

                Usuarios datos = new Usuarios();

                SqlDataReader LeerDatos = comando.ExecuteReader();

                if (LeerDatos.Read())
                {
                    datos.Id = LeerDatos.IsDBNull(0) ? 0 : LeerDatos.GetInt32(0);
                    datos.Nombre = LeerDatos.IsDBNull(1) ? "" : LeerDatos.GetString(1);
                }

                _conexion.Close();
                return datos;

            }
            catch (Exception ex)
            {
                _conexion.Close();

                return null;
            }
        }
    }
}
