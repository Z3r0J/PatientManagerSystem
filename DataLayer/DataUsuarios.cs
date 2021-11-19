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

        public Usuarios SeleccionCorreo(decimal Id)
        {
            _conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SeleccionCorreo", _conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id", Convert.ToInt32(Id));

            Usuarios datos = new Usuarios();

            SqlDataReader LeerDatos = comando.ExecuteReader();

            if (LeerDatos.Read())
            {
                datos.Id = LeerDatos.IsDBNull(0) ? 0 : LeerDatos.GetInt32(0);
                datos.Nombre = LeerDatos.IsDBNull(1) ? "" : LeerDatos.GetString(1);
                datos.Apellido = LeerDatos.IsDBNull(2) ? "" : LeerDatos.GetString(2);
                datos.Usuario = LeerDatos.IsDBNull(3) ? "" : LeerDatos.GetString(3);
                datos.Correo = LeerDatos.IsDBNull(4) ? "" : LeerDatos.GetString(4);
            }

            _conexion.Close();
            return datos;

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



        public bool Agregar(Usuarios usuarios)
        {
            bool add;
            SqlCommand cmd = new SqlCommand("SP_Agregar", _conexion);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@Nombre", usuarios.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", usuarios.Apellido);
            cmd.Parameters.AddWithValue("@Correo", usuarios.Correo);
            cmd.Parameters.AddWithValue("@UserName", usuarios.Usuario);
            cmd.Parameters.AddWithValue("@Password", usuarios.Contraseña);
            cmd.Parameters.AddWithValue("@TipoDeUsuario", usuarios.TipoDeUsuario);

            try
            {
                add = true;
                _conexion.Open();
                cmd.ExecuteNonQuery();
                RepositorioID.Instancia.Id=TomarIDInsertado();
                _conexion.Close();
                return add;
            }
            catch (Exception)
            {
                add = false;
                _conexion.Close();
                return add;
                
            }

        }

        public decimal TomarIDInsertado()
        {

            decimal id;
            SqlCommand comando = new SqlCommand("SELECT @@IDENTITY from Usuarios",_conexion);

            SqlDataReader LeerID = comando.ExecuteReader();

            if (LeerID.Read())
            {
                id = LeerID.IsDBNull(0) ? 0 : LeerID.GetDecimal(0);
                return id;
            }
            else
            {
                return 0;
            }

        }




        public bool ExecuteProc(SqlCommand comando)
        {
            try
            {
                _conexion.Open();
                comando.ExecuteNonQuery();
                _conexion.Close();
                return true;
            }
            catch (Exception ex)
            {
                _conexion.Close();
                return false;
            }
        }
    }
}
